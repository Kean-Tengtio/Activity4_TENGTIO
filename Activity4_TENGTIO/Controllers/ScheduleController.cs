using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Activity4_TENGTIO.Models;

namespace Activity4_TENGTIO.Controllers
{
    public class ScheduleController : ApiController
    {
        //-------CREATE OPERATION-------//
        public HttpResponseMessage Post(Schedule model)
        {
            try
            {
                IPT_Schedule dbcontext = new IPT_Schedule();
                Schedule schedule = new Schedule();
                schedule.ScheduleId = model.ScheduleId;
                schedule.Subject = model.Subject;
                schedule.Days = model.Days;
                schedule.Time = model.Time;
                schedule.Room = model.Room;
                schedule.Teacher = model.Teacher;
                dbcontext.Schedule.Add(schedule);
                dbcontext.SaveChanges();
                var response = Request.CreateResponse<Schedule>(HttpStatusCode.Created, schedule);
                return response;
            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
            
        }

        //-------READ OPERATION-------//
        //Get All Content
        public HttpResponseMessage Get()
        {
            IPT_Schedule dbcontext = new IPT_Schedule();
            var schedule = dbcontext.Schedule.ToList();
            var response = Request.CreateResponse<List<Schedule>>(HttpStatusCode.Accepted, schedule);
            return response;

        }
        //Get Specific Content
        public HttpResponseMessage Get(int id)
        {
            IPT_Schedule dbcontext = new IPT_Schedule();
            var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
            if (schedule != null)
            {
                var response = Request.CreateResponse<Schedule>(HttpStatusCode.Accepted, schedule);
                return response;
            }
            else //Not Found
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
        }

        //-------UPDATE OPERATION-------//
        public HttpResponseMessage Put(int id, Schedule model)
        {
            try
            {
                IPT_Schedule dbcontext = new IPT_Schedule();
                var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
                if (schedule != null)
                {
                    schedule.Subject = model.Subject;
                    schedule.Days = model.Days;
                    schedule.Time = model.Time;
                    schedule.Room = model.Room;
                    schedule.Teacher = model.Teacher;
                    dbcontext.SaveChanges();
                    var response = Request.CreateResponse<Schedule>(HttpStatusCode.Accepted, schedule);
                    return response;
                }
                else //Not Found
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound);
                    return response;
                }
                
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }

        }
        //-------DELETE OPERATION-------//
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                IPT_Schedule dbcontext = new IPT_Schedule();
                var schedule = dbcontext.Schedule.Where(m => m.ScheduleId == id).FirstOrDefault();
                if (schedule != null)
                {
                    dbcontext.Schedule.Remove(schedule);
                    dbcontext.SaveChanges();
                    var response = Request.CreateResponse<String>(HttpStatusCode.Accepted, "Successfully Deleted ID: "+id);
                    return response;
                }
                else //Not Found
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound);
                    return response;
                }
                
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }

        }

    }

}
