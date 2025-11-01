using EPEPITIAPI.Data;
using EPEPITIAPI.EPEPDbContext;
using EPEPITIAPI.Models;
using EPEPITIAPI.Models.BatchSection;
using EPEPITIAPI.Models.TrainingSection;
using EPEPITIAPI.Models.userInfoSection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly EPEPITIDbContext _service;
        protected APIResponse _response;


        public BatchController(EPEPITIDbContext service)
        {
            _service = service;
            _response = new();
        }


        [HttpPost("AddBatch")]
        public async Task<APIResponse> AddBatch([FromBody] AddBatchRequest model)
        {
            try
            {
                // ✅ 1. Validate model
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Validation failed.";
                    _response.Result = ModelState.Values.SelectMany(v => v.Errors)
                                                        .Select(e => e.ErrorMessage)
                                                        .ToList();
                    return _response;
                }

                // ✅ 2. Validate dates
                if (model.endDate <= model.startDate)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "End Date must be greater than Start Date.";
                    return _response;
                }

                using var transaction = await _service.Database.BeginTransactionAsync();

                // ✅ 3. Insert into TMBatch
                var newBatch = new TMBatch
                {
                    batchID = model.batchID,
                    sectorID = model.sectorID,
                    jobRoleID = model.jobRoleID,
                    jobDetailID = model.jobDetailID,
                    trainingCenterID = model.trainingCenterID,
                    trainerID = model.trainerID,
                    assessorID = model.assessorID,
                    startDate = model.startDate,
                    endDate = model.endDate,
                    status = model.status ?? 1,
                    createdBy = model.createdBy,
                    batch_ext_id = model.batch_ext_id,
                    batch_name = model.batch_name,
                    min_length = model.min_length,
                    max_length = model.max_length,
                    approval_status = model.approval_status ?? "Pending",
                    approval_date = model.approval_date,
                    reject_reason = model.reject_reason,
                    createdOn = DateTime.Now
                };

                _service.TMBatch.Add(newBatch);
                await _service.SaveChangesAsync();

                // ✅ 4. Auto-generate schedule data between startDate and endDate
                var scheduleList = new List<TMBatchSchedule>();

                DateTime currentDate = model.startDate;
                while (currentDate <= model.endDate)
                {
                    scheduleList.Add(new TMBatchSchedule
                    {
                        fk_batch_id = newBatch.id,
                        schedule_date = currentDate,
                        schedule_type = "Daily", // Default type; change as needed
                        created_date = DateTime.Now
                    });

                    currentDate = currentDate.AddDays(1);
                }

                await _service.TMBatchSchedule.AddRangeAsync(scheduleList);
                await _service.SaveChangesAsync();

                await transaction.CommitAsync();

                // ✅ 5. Success response
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.ActionResponse = "Batch and auto-generated schedule data added successfully.";
                _response.Result = new
                {
                    batch_id = newBatch.id,
                    totalSchedules = scheduleList.Count,
                    fromDate = model.startDate.ToString("yyyy-MM-dd"),
                    toDate = model.endDate.ToString("yyyy-MM-dd")
                };
            }
            catch (Exception ex)
            {
                await _service.Database.RollbackTransactionAsync();

                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ActionResponse = "An error occurred while adding batch data.";
                _response.Result = ex.Message;
            }

            return _response;
        }



        [HttpPost("UpdateBatch")]
        public async Task<APIResponse> UpdateBatch(int batchId, [FromBody] AddBatchRequest model)
        {
            var _response = new APIResponse();

            try
            {
                // ✅ Validate model
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Validation failed.";
                    _response.Result = ModelState.Values.SelectMany(v => v.Errors)
                                                        .Select(e => e.ErrorMessage)
                                                        .ToList();
                    return _response;
                }

                // ✅ Find existing batch
                var existingBatch = await _service.TMBatch
                    .FirstOrDefaultAsync(x => x.id == batchId);

                if (existingBatch == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Batch not found.";
                    return _response;
                }

                // ✅ Prevent modification of approved batches
                if (existingBatch.approval_status?.ToUpper() == "APPROVED")
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Approved batch cannot be modified.";
                    return _response;
                }

                // ✅ Validate date range
                if (model.endDate <= model.startDate)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "End Date must be greater than Start Date.";
                    return _response;
                }

                using var transaction = await _service.Database.BeginTransactionAsync();

                // ✅ Update batch details
                existingBatch.batchID = model.batchID;
                existingBatch.sectorID = model.sectorID;
                existingBatch.jobRoleID = model.jobRoleID;
                existingBatch.jobDetailID = model.jobDetailID;
                existingBatch.trainingCenterID = model.trainingCenterID;
                existingBatch.trainerID = model.trainerID;
                existingBatch.assessorID = model.assessorID;
                existingBatch.startDate = model.startDate;
                existingBatch.endDate = model.endDate;
                existingBatch.status = model.status ?? existingBatch.status;
                existingBatch.batch_ext_id = model.batch_ext_id;
                existingBatch.batch_name = model.batch_name;
                existingBatch.min_length = model.min_length;
                existingBatch.max_length = model.max_length;
                existingBatch.updatedOn = DateTime.Now;
                existingBatch.approval_status = model.approval_status ?? existingBatch.approval_status;
                existingBatch.reject_reason = model.reject_reason;

                _service.TMBatch.Update(existingBatch);
                await _service.SaveChangesAsync();

                // ✅ Remove old schedules
                var oldSchedules = await _service.TMBatchSchedule
                    .Where(s => s.fk_batch_id == batchId)
                    .ToListAsync();

                if (oldSchedules.Any())
                {
                    _service.TMBatchSchedule.RemoveRange(oldSchedules);
                    await _service.SaveChangesAsync();
                }

                // ✅ Generate new schedule records based on start & end date
                var newSchedules = new List<TMBatchSchedule>();
                DateTime currentDate = model.startDate.Date;

                while (currentDate <= model.endDate.Date)
                {
                    newSchedules.Add(new TMBatchSchedule
                    {
                        fk_batch_id = batchId,
                        schedule_date = currentDate,
                        schedule_type = "AUTO", // mark auto-generated type
                        created_date = DateTime.Now
                    });

                    currentDate = currentDate.AddDays(1);
                }

                await _service.TMBatchSchedule.AddRangeAsync(newSchedules);
                await _service.SaveChangesAsync();

                await transaction.CommitAsync();

                // ✅ Build response
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.ActionResponse = "Batch and schedule data updated successfully.";
                _response.Result = new
                {
                    batch_id = existingBatch.id,
                    batch_name = existingBatch.batch_name,
                    start_date = existingBatch.startDate,
                    end_date = existingBatch.endDate,
                    totalSchedules = newSchedules.Count
                };
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ActionResponse = "An error occurred while updating batch data.";
                _response.Result = ex.Message;
            }

            return _response;
        }



        [HttpGet("GetBatchList")]
        public async Task<APIResponse> GetBatchList()
        {
            var response = new APIResponse();

            try
            {
                var batchList = await _service.TMBatch
                    .OrderByDescending(x => x.id)
                    .Select(b => new
                    {
                        b.id,
                        b.batchID,
                        b.batch_name,
                        b.batch_ext_id,
                        b.sectorID,
                        b.jobRoleID,
                        b.jobDetailID,
                        b.trainingCenterID,
                        b.trainerID,
                        b.assessorID,
                        b.startDate,
                        b.endDate,
                        b.status,
                        b.createdBy,
                        b.min_length,
                        b.max_length,
                        b.approval_status,
                        b.approval_date,
                        b.reject_reason,

                        // Include schedule data
                        ScheduleData = _service.TMBatchSchedule
                                        .Where(s => s.fk_batch_id == b.id)
                                        .Select(s => new
                                        {
                                            s.pk_schedule_id,
                                            s.fk_batch_id,
                                            s.schedule_date,
                                            s.schedule_type,
                                            s.created_date,
                                            s.updated_date,
                                            s.deleted_date
                                        })
                                        .ToList()
                    })
                    .ToListAsync();

                if (batchList.Any())
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = batchList;
                    response.ActionResponse = "Batch list retrieved successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ActionResponse = "No batch records found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ActionResponse = "An error occurred while fetching batch data.";
                response.Result = ex.Message;
            }

            return response;
        }


        [HttpGet("GetBatchById/{id}")]
        public async Task<APIResponse> GetBatchById(int id)
        {
            var response = new APIResponse();

            try
            {
                var batchList = await _service.TMBatch
                     .Where(x => x.id == id)
                    .OrderByDescending(x => x.id)
                    .Select(b => new
                    {
                        b.id,
                        b.batchID,
                        b.batch_name,
                        b.batch_ext_id,
                        b.sectorID,
                        b.jobRoleID,
                        b.jobDetailID,
                        b.trainingCenterID,
                        b.trainerID,
                        b.assessorID,
                        b.startDate,
                        b.endDate,
                        b.status,
                        b.createdBy,
                        b.min_length,
                        b.max_length,
                        b.approval_status,
                        b.approval_date,
                        b.reject_reason,

                        // Include schedule data
                        ScheduleData = _service.TMBatchSchedule
                                        .Where(s => s.fk_batch_id == b.id)
                                        .Select(s => new
                                        {
                                            s.pk_schedule_id,
                                            s.fk_batch_id,
                                            s.schedule_date,
                                            s.schedule_type,
                                            s.created_date,
                                            s.updated_date,
                                            s.deleted_date
                                        })
                                        .ToList()
                    })
                    .ToListAsync();

                if (batchList.Any())
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = batchList;
                    response.ActionResponse = "Batch list retrieved successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ActionResponse = "No batch records found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ActionResponse = "An error occurred while fetching batch data.";
                response.Result = ex.Message;
            }

            return response;
        }



        [HttpPost("UpdateBatchStatus")]
        public async Task<APIResponse> UpdateBatchStatus(BatchApproveRejectReq req)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Validation failed.";
                    _response.Result = ModelState.Values.SelectMany(v => v.Errors)
                                                        .Select(e => e.ErrorMessage)
                                                        .ToList();
                    return _response;
                }

                var existingBatch = await _service.TMBatch
                    .FirstOrDefaultAsync(x => x.id == req.id);

                if (existingBatch == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Batch not found.";
                    return _response;
                }

                if (existingBatch.approval_status?.ToUpper() == "APPROVED")
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ActionResponse = "Approved batch cannot be modified.";
                    return _response;
                }

               

                using var transaction = await _service.Database.BeginTransactionAsync();

                // ✅ Update batch details
              
                existingBatch.batch_ext_id = req.batch_ext_id;               
                existingBatch.approval_date = DateTime.Now;
                existingBatch.approval_status = req.approval_status ?? existingBatch.approval_status;
                existingBatch.reject_reason = req.reject_reason;
                _service.TMBatch.Update(existingBatch);
                await _service.SaveChangesAsync();

                

                await transaction.CommitAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.ActionResponse = "Batch and schedule data updated successfully.";
                _response.Result = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ActionResponse = "An error occurred while updating batch data.";
                _response.Result = ex.Message;
            }

            return _response;
        }


    }
}
