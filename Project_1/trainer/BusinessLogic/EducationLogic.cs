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

            //DataEf.Entities.Edu edu = new DataEf.Entities.Edu();
            //edu.InstitutionName = iname;
            //edu.CourseName = cname;
            //edu.StartDate = Convert.ToDateTime(sdate);
            //edu.EndDate = Convert.ToDateTime(edate);
            //edu.Cgpa = cgpa;
            //edu.UsId = id;

            //DataHandle dt = new DataHandle();
            //dt.UserProfileAdd(edu);

            //Entities.AbdulContext cnt = new Entities.AbdulContext();
            //Entities.Edu edu = new Entities.Edu();
            //cnt.Edus.Add(ed);
            //int j = cnt.SaveChanges();

            //if (j > 0)
            //{
            //    Console.WriteLine("Education Added Sucessfully");
            //}
            //else
            //{
            //    Console.WriteLine("Unable to add");
            //}
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



    }


}

