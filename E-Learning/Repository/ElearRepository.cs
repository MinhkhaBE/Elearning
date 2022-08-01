using E_Learning.Data;
using E_Learning.Interfaces;
using E_Learning.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Repository
{
    public class ElearRepository : IRepository
    {
        private readonly MyDbContext _context;

        public ElearRepository(MyDbContext context)
        {
            _context = context;
        }
        public Accountmodel CreateNewAccount(Account account)
        {
            var Account = new Account
            {
                User = account.User,
                Password = account.Password,
                Gmail = account.Gmail,
                Phone = account.Phone,
                Type = account.Type,
                Createdate = account.Createdate
            };
            _context.Add(Account);
            _context.SaveChanges();
            return new Accountmodel
            {
                User = account.User,
                Password = account.Password,
                Gmail = account.Gmail,
                Phone = account.Phone,
                Type = account.Type,
                Createdate = account.Createdate
            };
        }

        public Adminmodel CreateNewAdmin(Admin admin)
        {
            var Admin = new Admin
            {
                Nameadmin = admin.Nameadmin,
                Phone = admin.Phone,
                Gender = admin.Gender,
                Idaccount = admin.Idaccount,

            };

            _context.Add(Admin);
            _context.SaveChanges();
            return new Adminmodel
            {
                Nameadmin = admin.Nameadmin,
                Phone = admin.Phone,
                Gender = admin.Gender,
                Idaccount = admin.Idaccount
            };
        }

        public Classmodel CreateNewClass(Class classs)
        {
            var Class = new Class
            {
                Nameclass = classs.Nameclass,
                Topic = classs.Topic,
                Semester = classs.Semester,
                Status = classs.Status,
                Idsubject = classs.Idsubject
            };
            _context.Add(Class);
            _context.SaveChanges();
            return new Classmodel
            {
                Nameclass = classs.Nameclass,
                Topic = classs.Topic,
                Semester = classs.Semester,
                Status = classs.Status,
                Idsubject = classs.Idsubject
            };
        }

        public Classdetailmodel CreateNewClassdetail(Classdetail classdetail)
        {
            var Classdetail = new Classdetail
            {
                Passwordclass = classdetail.Passwordclass,
                Teacher = classdetail.Teacher,
                Lesson = classdetail.Lesson,
                Studytime = classdetail.Studytime,
                Schedule = classdetail.Schedule,
                description = classdetail.description,
                Idclass = classdetail.Idclass
            };
            _context.Add(Classdetail);
            _context.SaveChanges();
            return new Classdetailmodel
            {
                Passwordclass = classdetail.Passwordclass,
                Teacher = classdetail.Teacher,
                Lesson = classdetail.Lesson,
                Studytime = classdetail.Studytime,
                Schedule = classdetail.Schedule,
                description = classdetail.description,
                Idclass = classdetail.Idclass
            };
        }

        public Scoremodel CreateNewScore(Scorelearning score)
        {
            var Score = new Scorelearning
            {
                Scorediligence = score.Scorediligence,
                Scoreoral = score.Scoreoral,
                Score15min = score.Score15min,
                Scorecorfficient2 = score.Scorecorfficient2,
                Scorecorfficient3 = score.Scorecorfficient3,
                Mediumscore = score.Mediumscore,
                Totalscore = score.Totalscore,
                Result = score.Result,
                Updatedate = score.Updatedate,
                Idstudent = score.Idstudent,
                Idsubject = score.Idsubject
            };
            _context.Add(Score);
            _context.SaveChanges();
            return new Scoremodel
            {
                Scorediligence = score.Scorediligence,
                Scoreoral = score.Scoreoral,
                Score15min = score.Score15min,
                Scorecorfficient2 = score.Scorecorfficient2,
                Scorecorfficient3 = score.Scorecorfficient3,
                Mediumscore = score.Mediumscore,
                Totalscore = score.Totalscore,
                Result = score.Result,
                Updatedate = score.Updatedate,
                Idstudent = score.Idstudent,
                Idsubject = score.Idsubject
            };   
            }

        public Studentmodel CreateNewStudent(Student student)
        {
            var Student = new Student
            {
                Namestudent = student.Namestudent,
                Gmail = student.Gmail,
                Phone = student.Phone,
                Gender = student.Gender,
                Birth = student.Birth,
                Idaccount = student.Idaccount
            };
            _context.Add(Student);
            _context.SaveChanges();
            return new Studentmodel
            {
                Namestudent = student.Namestudent,
                Gmail = student.Gmail,
                Phone = student.Phone,
                Gender = student.Gender,
                Birth = student.Birth,
                Idaccount = student.Idaccount
            };
        }

        public Subjectmodel CreateNewSubject(Subject subject)
        {
            var Subject = new Subject
            {
                Namesubject = subject.Namesubject
            };
            _context.Add(Subject);
            _context.SaveChanges();
            return new Subjectmodel
            {
                Namesubject = subject.Namesubject
            };
        }

        public Teachermodel CreateNewTeacher(Teacher teacher)
        {
            var Teacher = new Teacher
            {
                Nameteacher = teacher.Nameteacher,
                Gmail = teacher.Phone,
                Phone = teacher.Phone,
                Gender = teacher.Gender,
                Birth = teacher.Birth,
                Idaccount = teacher.Idaccount
            };
            _context.Add(Teacher);
            _context.SaveChanges();
            return new Teachermodel
            {
                Nameteacher = teacher.Nameteacher,
                Gmail = teacher.Phone,
                Phone = teacher.Phone,
                Gender = teacher.Gender,
                Birth = teacher.Birth,
                Idaccount = teacher.Idaccount
            };
        }

        public Testmodel CreateNewTest(Test test)
        {
            var Test = new Test
            {
                Nametest = test.Nametest,
                Content = test.Content,
                Time = test.Time,
                Createdate = test.Createdate,
                Score = test.Score,
                Status = test.Status,
                Idsubject = test.Idsubject,
            };
            _context.Add(Test);
            _context.SaveChanges();
            return new Testmodel
            {
                Nametest = test.Nametest,
                Content = test.Content,
                Time = test.Time,
                Createdate = test.Createdate,
                Score = test.Score,
                Status = test.Status,
                Idsubject = test.Idsubject,
            };
        }

        public void DeleteByIdAccount(int Accountid)
        {
            var Account = _context.Accounts.SingleOrDefault(ac => ac.Idaccount == Accountid);
            if (Account != null)
            {
                _context.Remove(Account);
                _context.SaveChanges();
            }

        }

        public void DeleteByIdAdmin(int Admintid)
        {
            var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == Admintid);
            if (Admin != null)
            {
                _context.Remove(Admin);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdClass(int Classid)
        {
            var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == Classid);
            if (Class != null)
            {
                _context.Remove(Class);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdClassdetail(int classdetailid)
        {
            var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == classdetailid);
            if (Classdetail != null)
            {
                _context.Remove(Classdetail);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdScore(int scoreid)
        {
            var Score = _context.Scorelearnings.SingleOrDefault(cld => cld.Idscore == scoreid);
            if (Score != null)
            {
                _context.Remove(Score);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdStudent(int studentid)
        {
            var Student = _context.Students.SingleOrDefault(st => st.Idstudent == studentid);
            if (Student != null)
            {
                _context.Remove(Student);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdSubject(int subjectid)
        {
            var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == subjectid);
            if (Subject != null)
            {
                _context.Remove(Subject);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdTeacher(int teacherid)
        {
            var Teacher = _context.Teachers.SingleOrDefault(te => te.Idteacher == teacherid);
            if (Teacher != null)
            {
                _context.Remove(Teacher);
                _context.SaveChanges();
            }
        }

        public void DeleteByIdTest(int testid)
        {
            var Test = _context.Tests.SingleOrDefault(te => te.Idtest == testid);
            if (Test != null)
            {
                _context.Remove(Test);
                _context.SaveChanges();
            }
        }

        public List<Accountmodel> GetAllAccount()
        {
            var dsAccount = _context.Accounts.Select(ac => new Accountmodel
            {
                Idaccount = ac.Idaccount,
                User = ac.User,
                Password = ac.Password,
                Gmail = ac.Gmail,
                Phone = ac.Phone,
                Type = ac.Type,
                Createdate = ac.Createdate
            });
            return dsAccount.ToList();
        }

        public List<Adminmodel> GetAllAdmin()
        {
            var dsAdmin = _context.Admins.Select(ad => new Adminmodel
            {
                Idadmin = ad.Idadmin,
                Nameadmin = ad.Nameadmin,
                Phone = ad.Phone,
                Gender = ad.Gender,
                Idaccount = ad.Idaccount,
            });
            return dsAdmin.ToList();
        }

        public List<Classmodel> GetAllClass()
        {
            var dsClass = _context.Classes.Select(cl => new Classmodel
            {
                Idclass = cl.Idclass,
                Nameclass = cl.Nameclass,
                Topic = cl.Topic,
                Semester = cl.Semester,
                Status = cl.Status,
                Idsubject = cl.Idsubject
            });
            return dsClass.ToList();
        }

        public List<Classdetailmodel> GetAllClassdetail()
        {
            var dsClassdetail = _context.Classdetails.Select(cld => new Classdetailmodel
            {
                Idclassdetail = cld.Idclassdetail,
                Passwordclass = cld.Passwordclass,
                Teacher = cld.Teacher,
                Lesson = cld.Lesson,
                Studytime = cld.Studytime,
                Schedule = cld.Schedule,
                description = cld.description,
                Idclass = cld.Idclass
            });
            return dsClassdetail.ToList();
        }

        public List<Scoremodel> GetAllScore()
        {
            var dsScore = _context.Scorelearnings.Select(sc => new Scoremodel
            {
                Scorediligence = sc.Scorediligence,
                Scoreoral = sc.Scoreoral,
                Score15min = sc.Score15min,
                Scorecorfficient2 = sc.Scorecorfficient2,
                Scorecorfficient3 = sc.Scorecorfficient3,
                Mediumscore = sc.Mediumscore,
                Totalscore = sc.Totalscore,
                Result = sc.Result,
                Updatedate = sc.Updatedate,
                Idstudent = sc.Idstudent,
                Idsubject = sc.Idsubject
            });
            return dsScore.ToList();
        }

        public List<Studentmodel> GetAllStudent()
        {
            var dsStudent = _context.Students.Select(st => new Studentmodel
            {
                Namestudent = st.Namestudent,
                Gmail = st.Gmail,
                Phone = st.Phone,
                Gender = st.Gender,
                Birth = st.Birth,
                Idaccount = st.Idaccount
            });
            return dsStudent.ToList();
        }

        public List<Subjectmodel> GetAllSubject()
        {
            var dsSubject = _context.Subjects.Select(su => new Subjectmodel
            {
                Namesubject = su.Namesubject
            });
            return dsSubject.ToList();
        }

        public List<Teachermodel> GetAllTeacher()
        {
            var dsTeacher = _context.Teachers.Select(te => new Teachermodel
            {
                Nameteacher = te.Nameteacher,
                Gmail = te.Phone,
                Phone = te.Phone,
                Gender = te.Gender,
                Birth = te.Birth,
                Idaccount = te.Idaccount
            });
            return dsTeacher.ToList();
        }

        public List<Testmodel> GetAllTest()
        {
            var dsTest = _context.Tests.Select(te => new Testmodel
            {
                Nametest = te.Nametest,
                Content = te.Content,
                Time = te.Time,
                Createdate = te.Createdate,
                Score = te.Score,
                Status = te.Status,
                Idsubject = te.Idsubject,
            });
            return dsTest.ToList();
        }

        public Accountmodel GetByIdAccount(int Accountid)
        {
            var Account = _context.Accounts.SingleOrDefault(acc => acc.Idaccount == Accountid);
            if (Account != null)
            {
                return new Accountmodel
                {
                    Idaccount = Account.Idaccount,
                    User = Account.User,
                    Password = Account.Password,
                    Gmail = Account.Gmail,
                    Phone = Account.Phone,
                    Type = Account.Type,
                    Createdate = Account.Createdate
                };
            }
            else
            {
                return null;
            }
        }

        public Adminmodel GetByIdAdmin(int Adminid)
        {
            var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == Adminid);
            if (Admin != null)
            {
                return new Adminmodel
                {
                    Idadmin = Admin.Idadmin,
                    Nameadmin = Admin.Nameadmin,
                    Phone = Admin.Phone,
                    Gender = Admin.Gender,
                    Idaccount = Admin.Idaccount,
                };
            }
            else
            {
                return null;
            }
        }

        public Classmodel GetByIdClass(int Classid)
        {
            var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == Classid);
            if (Class != null)
            {
                return new Classmodel
                {
                    Idclass = Class.Idclass,
                    Nameclass = Class.Nameclass,
                    Topic = Class.Topic,
                    Semester = Class.Semester,
                    Status = Class.Status,
                    Idsubject = Class.Idsubject
                };
            }
            else
            {
                return null;
            }
        }

        public Classdetailmodel GetByIdClassdetail(int classdetailid)
        {
            var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == classdetailid);
            if (Classdetail != null)
            {
                return new Classdetailmodel
                {
                    Idclassdetail = Classdetail.Idclassdetail,
                    Passwordclass = Classdetail.Passwordclass,
                    Teacher = Classdetail.Teacher,
                    Lesson = Classdetail.Lesson,
                    Studytime = Classdetail.Studytime,
                    Schedule = Classdetail.Schedule,
                    description = Classdetail.description,
                    Idclass = Classdetail.Idclass
                };
            }
            else
            {
                return null;
            }
        }

        public Scoremodel GetByIdScore(int scoreid)
        {
            var Score = _context.Scorelearnings.SingleOrDefault(sc => sc.Idscore == scoreid);
            if (Score != null)
            {
                return new Scoremodel
                {
                    Scorediligence = Score.Scorediligence,
                    Scoreoral = Score.Scoreoral,
                    Score15min = Score.Score15min,
                    Scorecorfficient2 = Score.Scorecorfficient2,
                    Scorecorfficient3 = Score.Scorecorfficient3,
                    Mediumscore = Score.Mediumscore,
                    Totalscore = Score.Totalscore,
                    Result = Score.Result,
                    Updatedate = Score.Updatedate,
                    Idstudent = Score.Idstudent,
                    Idsubject = Score.Idsubject
                };
            }
            else
            {
                return null;
            }
        }

        public Studentmodel GetByIdStudent(int studentid)
        {
            var Student = _context.Students.SingleOrDefault(st => st.Idstudent == studentid);
            if (Student != null)
            {
                return new Studentmodel
                {
                    Namestudent = Student.Namestudent,
                    Gmail = Student.Gmail,
                    Phone = Student.Phone,
                    Gender = Student.Gender,
                    Birth = Student.Birth,
                    Idaccount = Student.Idaccount
                };
            }
            else
            {
                return null;
            }
        }

        public Subjectmodel GetByIdSubject(int subjectid)
        {
            var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == subjectid);
            if (Subject != null)
            {
                return new Subjectmodel
                {
                    Namesubject = Subject.Namesubject
                };
            }
            else
            {
                return null;
            }
        }

        public Teachermodel GetByIdTeacher(int teacherid)
        {
            var Teacher = _context.Teachers.SingleOrDefault(te => te.Idteacher == teacherid);
            if (Teacher != null)
            {
                return new Teachermodel
                {
                    Nameteacher = Teacher.Nameteacher,
                    Gmail = Teacher.Phone,
                    Phone = Teacher.Phone,
                    Gender = Teacher.Gender,
                    Birth = Teacher.Birth,
                    Idaccount = Teacher.Idaccount
                };
            }
            else
            {
                return null;
            }
        }

        public Testmodel GetByIdTest(int testid)
        {
            var Test = _context.Tests.SingleOrDefault(te => te.Idtest == testid);
            if (Test != null)
            {
                return new Testmodel
                {
                    Nametest = Test.Nametest,
                    Content = Test.Content,
                    Time = Test.Time,
                    Createdate = Test.Createdate,
                    Score = Test.Score,
                    Status = Test.Status,
                    Idsubject = Test.Idsubject,
                };
            }
            else
            {
                return null;
            }
        }

        public void UpdateByIdAccount(Accountmodel account)
        {
            var Account = _context.Accounts.SingleOrDefault(acc => acc.Idaccount == account.Idaccount);
            if (Account != null)
            {
                Account.User = account.User;
                Account.Password = account.Password;
                Account.Gmail = account.Gmail;
                Account.Phone = account.Phone;
                Account.Type = account.Type;
                Account.Createdate = account.Createdate;
                _context.SaveChanges();

            }
        }

        public void UpdateByIdAdmin(Adminmodel admin)
        {
            var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == admin.Idadmin);
            if (Admin != null)
            {
                Admin.Nameadmin = admin.Nameadmin;
                Admin.Phone = admin.Phone;
                Admin.Gender = admin.Gender;
                Admin.Idaccount = admin.Idaccount;
                _context.SaveChanges();

            }
        }

        public void UpdateByIdClass(Classmodel classs)
        {
            var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == classs.Idclass);
            if (Class != null)
            {
                Class.Nameclass = classs.Nameclass;
                Class.Topic = classs.Topic;
                Class.Semester = classs.Semester;
                Class.Status = classs.Status;
                Class.Idsubject = classs.Idsubject;
                _context.SaveChanges();
             
            }
        }

        public void UpdateByIdClassdetail(Classdetailmodel classdetail)
        {
            var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == classdetail.Idclassdetail);
            if (Classdetail != null)
            {
                Classdetail.Passwordclass = classdetail.Passwordclass;
                Classdetail.Teacher = classdetail.Teacher;
                Classdetail.Lesson = classdetail.Lesson;
                Classdetail.Studytime = classdetail.Studytime;
                Classdetail.Schedule = classdetail.Schedule;
                Classdetail.description = classdetail.description;
                Classdetail.Idclass = classdetail.Idclass;
                _context.SaveChanges();
            }
        }

        public void UpdateByIdScore(Scoremodel score)
        {
            var Score = _context.Scorelearnings.SingleOrDefault(sc => sc.Idscore == score.Idscore);
            if (Score != null)
            {
                Score.Scorediligence = score.Scorediligence;
                Score.Scoreoral = score.Scoreoral;
                Score.Score15min = score.Score15min;
                Score.Scorecorfficient2 = score.Scorecorfficient2;
                Score.Scorecorfficient3 = score.Scorecorfficient3;
                Score.Mediumscore = score.Mediumscore;
                Score.Totalscore = score.Totalscore;
                Score.Result = score.Result;
                Score.Updatedate = score.Updatedate;
                Score.Idstudent = score.Idstudent; ;
                Score.Idsubject = score.Idsubject;
                _context.SaveChanges();
            }
        }

        public void UpdateByIdStudent(Studentmodel student)
        {
            var Student = _context.Students.SingleOrDefault(st => st.Idstudent == student.Idstudent);
            if (Student != null)
            {
                Student.Namestudent = student.Namestudent;
                Student.Gmail = student.Gmail;
                Student.Phone = student.Phone;
                Student.Gender = student.Gender;
                Student.Birth = student.Birth;
                Student.Idaccount = student.Idaccount;
                _context.SaveChanges();
            }
        }

        public void UpdateByIdSubject(Subjectmodel subject)
        {
            var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == subject.Idsubject);
            if (Subject != null)
            {
                Subject.Namesubject = subject.Namesubject;
                _context.SaveChanges();
            }
        }

        public void UpdateByIdTeacher(Teachermodel teacher)
        {
            var Teacher = _context.Teachers.SingleOrDefault(te => te.Idteacher == teacher.Idteacher);
            if (Teacher != null)
            {
                Teacher.Nameteacher = teacher.Nameteacher;
                Teacher.Gmail = teacher.Phone;
                Teacher.Phone = teacher.Phone;
                Teacher.Gender = teacher.Gender;
                Teacher.Birth = teacher.Birth;
                Teacher.Idaccount = teacher.Idaccount;
                _context.SaveChanges();
            }
        }

        public void UpdateByIdTest(Testmodel test)
        {
            var Test = _context.Tests.SingleOrDefault(te => te.Idtest == test.Idtest);
            if (Test != null)
            {
                Test.Nametest = test.Nametest;
                Test.Content = test.Content;
                Test.Time = test.Time;
                Test.Createdate = test.Createdate;
                Test.Score = test.Score;
                Test.Status = test.Status;
                Test.Idsubject = test.Idsubject;
                _context.SaveChanges();
            }
        }
    }
}
