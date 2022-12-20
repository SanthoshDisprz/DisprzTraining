using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisprzTraining.Data;
using Appointments;

namespace DisprzTraining.DataAccess
{
    public class AppointmentDAL : IAppointmentDAL
    {
        public Task<List<Appointment>> GetAllAppointments()
        {
            return Task.FromResult(AppointmentStore.AppointmentList);
        }
        public Task<List<Appointment>> GetAppointments(string appointmentDate)
        {
            return Task.FromResult(AppointmentStore.AppointmentList.Where(appointment => appointment.AppointmentDate.Equals(appointmentDate)).ToList());
        }
        public Task<List<Appointment>> GetAppointmentById(Guid id)
        {
            return Task.FromResult(AppointmentStore.AppointmentList.Where(appointment => appointment.Id==id).ToList());
        }


        public Task<bool> CreateAppointment(Appointment appointment)
        {

            AppointmentStore.AppointmentList.Add(appointment);
            return Task.FromResult(true);
        }
        public Task<bool> DeleteAppointment(Appointment appointment)
        {
            AppointmentStore.AppointmentList.Remove(appointment);
            return Task.FromResult(true);
        }
        public Task<bool> UpdateAppointment(Appointment appointmentToBeUpdated,Appointment appointment)
        {
            appointmentToBeUpdated.AppointmentDate=appointment.AppointmentDate;
            appointmentToBeUpdated.AppointmentTitle=appointment.AppointmentTitle;
            appointmentToBeUpdated.AppointmentStartTime=appointment.AppointmentStartTime;
            appointmentToBeUpdated.AppointmentEndTime=appointment.AppointmentEndTime;
            appointmentToBeUpdated.AppointmentDescription=appointment.AppointmentDescription;
            return Task.FromResult(true);
        }
    }
}