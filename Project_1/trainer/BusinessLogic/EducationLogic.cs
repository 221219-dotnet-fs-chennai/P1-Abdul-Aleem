using System;
using System.Linq;
using Models;
using AutoMapper;
using System.Collections.Generic;
using System.Collections;
using DataEf;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic
{
    public class EducationLogic
    {

        public IList GetAll(int id)
        {
            DataEf.Entities.AbdulContext cnt = new DataEf.Entities.AbdulContext();
            var query = (from st in cnt.Edus
                         where st.UsId == id
                         select st).ToList();

            var tr = query.Select(x => new EduModel()
            {
                EduId = x.EduId,
                CourseName = x.CourseName,
                InstitutionName = x.InstitutionName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Cgpa = x.Cgpa,
            }).ToList();
            return tr;
        }

        public bool Add(int id, AEduModel aEduModel)
        {

            DataEf.Entities.Edu edu = new DataEf.Entities.Edu();

            edu.InstitutionName = aEduModel.InstitutionName;
            edu.CourseName = aEduModel.CourseName;
            edu.StartDate = aEduModel.StartDate;
            edu.EndDate = aEduModel.EndDate;
            edu.Cgpa = aEduModel.Cgpa;
            edu.UsId = id;

            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Edus.Add(edu);
            int res = abdulContext.SaveChanges();

            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            DataEf.Entities.Edu edu = new DataEf.Entities.Edu() { EduId = id };
            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Edus.Attach(edu);
            abdulContext.Edus.Remove(edu);
            int k = abdulContext.SaveChanges();
            if (k > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int id, UEduModel uEduModel)
        {
            DataEf.Entities.Edu edu = new DataEf.Entities.Edu();
            edu.EduId = uEduModel.EduId;
            edu.CourseName = uEduModel.CourseName;
            edu.InstitutionName = uEduModel.InstitutionName;
            edu.StartDate = uEduModel.StartDate;
            edu.EndDate = uEduModel.EndDate;
            edu.Cgpa = uEduModel.Cgpa;
            edu.UsId = id;


            //Entities.AbdulContext cnt = new Entities.AbdulContext();
            //Entities.Edu edu1 = new Entities.Edu();
            //cnt.Edus.Update(edu);
            //int j = cnt.SaveChanges();
            //if (j > 0)
            //{
            //    Console.WriteLine("Education updated successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Unable to update");
            //}


            DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();
            abdulContext.Edus.Update(edu);
            int j = abdulContext.SaveChanges();

            if (j > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }


}

