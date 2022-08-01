using E_Learning.Data;
using E_Learning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Interfaces
{
    public interface IRepository
    {
        //account//
        List<Accountmodel> GetAllAccount();
        Accountmodel GetByIdAccount(int Accountid);
        Accountmodel CreateNewAccount(Account account);
        void  UpdateByIdAccount( Accountmodel account);
        void  DeleteByIdAccount(int Accountid);

        //admin//
        List<Adminmodel> GetAllAdmin();
        Adminmodel GetByIdAdmin(int Adminid);
        Adminmodel CreateNewAdmin(Admin admin);
        void UpdateByIdAdmin(Adminmodel admin);
        void DeleteByIdAdmin(int Admintid);

        //class//
        List<Classmodel> GetAllClass();
        Classmodel GetByIdClass(int Classid);
        Classmodel CreateNewClass(Class classs);
        void UpdateByIdClass(Classmodel classs);
        void DeleteByIdClass(int Classid);

        //classdetail//
        List<Classdetailmodel> GetAllClassdetail();
        Classdetailmodel GetByIdClassdetail(int classdetailid);
        Classdetailmodel CreateNewClassdetail(Classdetail classdetail);
        void UpdateByIdClassdetail(Classdetailmodel classdetail);
        void DeleteByIdClassdetail(int classdetailid);

        //score//
        List<Scoremodel> GetAllScore();
        Scoremodel GetByIdScore(int scoreid);
        Scoremodel CreateNewScore(Scorelearning score);
        void UpdateByIdScore(Scoremodel score);
        void DeleteByIdScore(int scoreid);

        //student//
        List<Studentmodel> GetAllStudent();
        Studentmodel GetByIdStudent(int studentid);
        Studentmodel CreateNewStudent(Student student);
        void UpdateByIdStudent(Studentmodel student);
        void DeleteByIdStudent(int studentid);

        //subject//
        List<Subjectmodel> GetAllSubject();
        Subjectmodel GetByIdSubject(int subjectid);
        Subjectmodel CreateNewSubject(Subject subject);
        void UpdateByIdSubject(Subjectmodel subject);
        void DeleteByIdSubject(int subjectid);

        //teacher//
        List<Teachermodel> GetAllTeacher();
        Teachermodel GetByIdTeacher(int teacherid);
        Teachermodel CreateNewTeacher(Teacher teacher);
        void UpdateByIdTeacher(Teachermodel teacher);
        void DeleteByIdTeacher(int teacherid);

        //test//
        List<Testmodel> GetAllTest();
        Testmodel GetByIdTest(int testid);
        Testmodel CreateNewTest(Test test);
        void UpdateByIdTest(Testmodel test);
        void DeleteByIdTest(int testid);
    }
}
