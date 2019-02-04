using eGradebook.Infrastructure;
using eGradebook.Models.UserModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class InitializeWithDefaultData : DropCreateDatabaseAlways<eGradebookContext>
    {
        protected override void Seed(eGradebookContext context)
        {
            using (var store = new RoleStore<IdentityRole>(context))
            {
                using (var manager = new RoleManager<IdentityRole>(store))
                {
                    manager.Create(new IdentityRole("admin"));
                    manager.Create(new IdentityRole("teacher"));
                    manager.Create(new IdentityRole("student"));
                    manager.Create(new IdentityRole("parent"));
                }
            }

            using (var userStore = new UserStore<User>(context))
            {
                using (var userManager = new UserManager<User>(userStore))
                {
                    //admins
                    User admin1 = new Admin();
                    admin1.FirstName = "Albus";
                    admin1.LastName = "Dumbledore";
                    admin1.Email = "headmaster@hogwarts.com";
                    admin1.UserName = "dumbledore";
                    userManager.Create(admin1, "sherbetlemons");
                    userManager.AddToRole(admin1.Id, "admin");


                    //teachers
                    Teacher teacher1 = new Teacher();
                    teacher1.FirstName = "Severus";
                    teacher1.LastName = "Snape";
                    teacher1.Email = "professorsnape@hogwarts.com";
                    teacher1.UserName = "professorsnape";
                    userManager.Create(teacher1, "slytherin");
                    userManager.AddToRole(teacher1.Id, "teacher");

                    Teacher teacher2 = new Teacher();
                    teacher2.FirstName = "Filius";
                    teacher2.LastName = "Flitwick";
                    teacher2.Email = "professorflitwick@hogwarts.com";
                    teacher2.UserName = "professorflitwick";
                    userManager.Create(teacher2, "ravenclaw");
                    userManager.AddToRole(teacher2.Id, "teacher");

                    Teacher teacher3 = new Teacher();
                    teacher3.FirstName = "Pomona";
                    teacher3.LastName = "Sprout";
                    teacher3.Email = "professorsprout@hogwarts.com";
                    teacher3.UserName = "professorsprout";
                    userManager.Create(teacher3, "hufflepuff");
                    userManager.AddToRole(teacher3.Id, "teacher");

                    Teacher teacher4 = new Teacher();
                    teacher4.FirstName = "Minerva";
                    teacher4.LastName = "McGonagall";
                    teacher4.Email = "headmistress@hogwarts.com";
                    teacher4.UserName = "headmistress";
                    userManager.Create(teacher4, "gryffindor");
                    userManager.AddToRole(teacher4.Id, "teacher");

                    //parents
                    Parent parent1 = new Parent();
                    parent1.FirstName = "Molly";
                    parent1.LastName = "Weasley";
                    parent1.UserName = "mollyweasley";
                    parent1.Email = "wasleys@theburrow.com";
                    userManager.Create(parent1, "mollypass");
                    userManager.AddToRole(parent1.Id, "parent");

                    Parent parent2 = new Parent();
                    parent2.FirstName = "Sirius";
                    parent2.LastName = "Black";
                    parent2.UserName = "siriusblack";
                    parent2.Email = "siriusblack@grimmauldplace.com";
                    userManager.Create(parent2, "padfoot");
                    userManager.AddToRole(parent2.Id, "parent");

                    Parent parent3 = new Parent();
                    parent3.FirstName = "Monica";
                    parent3.LastName = "Granger";
                    parent3.UserName = "monicagranger";
                    userManager.Create(parent3, "monicapass");
                    userManager.AddToRole(parent3.Id, "parent");

                    Parent parent4 = new Parent();
                    parent4.FirstName = "Xenophillius";
                    parent4.LastName = "Lovegood";
                    parent4.UserName = "xlovegood";
                    parent4.Email = "xeno@thequibbler.com";
                    userManager.Create(parent4, "xenopass");
                    userManager.AddToRole(parent4.Id, "parent");

                    //students
                    Student student1 = new Student();
                    student1.FirstName = "Harry";
                    student1.LastName = "Potter";
                    student1.UserName = "harrypotter";
                    student1.Parent = parent2;
                    userManager.Create(student1, "hedwig11");
                    userManager.AddToRole(student1.Id, "student");

                    Student student2 = new Student();
                    student2.FirstName = "Hermione";
                    student2.LastName = "Granger";
                    student2.UserName = "hermionegranger";
                    student2.Parent = parent3;
                    userManager.Create(student2, "crookshanks");
                    userManager.AddToRole(student2.Id, "student");

                    Student student3 = new Student();
                    student3.FirstName = "Ronald";
                    student3.LastName = "Weasley";
                    student3.UserName = "ronweasley";
                    student3.Parent = parent1;
                    userManager.Create(student3, "scabbers");
                    userManager.AddToRole(student3.Id, "student");

                    Student student4 = new Student();
                    student4.FirstName = "Luna";
                    student4.LastName = "Lovegood";
                    student4.UserName = "lunalovegood";
                    student4.Parent = parent4;
                    userManager.Create(student4, "narglesarereal");
                    userManager.AddToRole(student4.Id, "student");

                    Student student5 = new Student();
                    student5.FirstName = "Ginevra";
                    student5.LastName = "Weasley";
                    student5.UserName = "ginnyweasley";
                    student5.Parent = parent1;
                    userManager.Create(student5, "ginnyweasley");
                    userManager.AddToRole(student5.Id, "student");


                    //school year
                    SchoolYear sy1 = new SchoolYear();
                    sy1.Name = "2018/2019";
                    sy1.StartDate = new DateTime(2018, 9, 1);
                    sy1.EndDate = new DateTime(2019, 8, 31);


                    //subjects
                    IList<Subject> subjects = new List<Subject>();

                    Subject subject1 = new Subject();
                    subject1.Name = "English";
                    subject1.Grade = Grade.FIFTH;
                    subject1.ClassesPerWeek = 5;
                    subjects.Add(subject1);

                    Subject subject2 = new Subject();
                    subject2.Name = "English";
                    subject2.Grade = Grade.SEVENTH;
                    subject2.ClassesPerWeek = 4;
                    subjects.Add(subject2);

                    Subject subject3 = new Subject();
                    subject3.Name = "Mathematics";
                    subject3.Grade = Grade.FIFTH;
                    subject3.ClassesPerWeek = 5;
                    subjects.Add(subject3);

                    Subject subject4 = new Subject();
                    subject4.Name = "Chemistry";
                    subject4.Grade = Grade.SEVENTH;
                    subject4.ClassesPerWeek = 2;
                    subjects.Add(subject4);

                    foreach (Subject subject in subjects)
                        context.Subjects.Add(subject);
                    base.Seed(context);

                    //teacher teaches subjects
                    IList<TeacherTeachesCourse> tts = new List<TeacherTeachesCourse>();

                    TeacherTeachesCourse tts1 = new TeacherTeachesCourse();
                    tts1.Teacher = teacher1;
                    tts1.Subject = subject3;
                    tts.Add(tts1);

                    TeacherTeachesCourse tts2 = new TeacherTeachesCourse();
                    tts2.Teacher = teacher1;
                    tts2.Subject = subject4;
                    tts.Add(tts2);

                    TeacherTeachesCourse tts3 = new TeacherTeachesCourse();
                    tts3.Teacher = teacher2;
                    tts3.Subject = subject1;
                    tts.Add(tts3);

                    TeacherTeachesCourse tts4 = new TeacherTeachesCourse();
                    tts4.Teacher = teacher2;
                    tts4.Subject = subject2;
                    tts.Add(tts4);

                    foreach (TeacherTeachesCourse tts0 in tts)
                        context.TeacherTeachesCourse.Add(tts0);
                    base.Seed(context);

                    //school classes
                    IList<SchoolClass> sc = new List<SchoolClass>();

                    SchoolClass sc1 = new SchoolClass();
                    sc1.Grade = Grade.FIFTH;
                    sc1.Section = "A";
                    sc1.SchoolYear = sy1;
                    sc1.Students = new List<Student>();
                    sc1.Students.Add(student5);
                    sc1.Courses = new List<TeacherTeachesCourse>();
                    sc1.Courses.Add(tts1);
                    sc1.Courses.Add(tts3);
                    sc.Add(sc1);
                    

                    SchoolClass sc2 = new SchoolClass();
                    sc2.Grade = Grade.FIFTH;
                    sc2.Section = "B";
                    sc2.SchoolYear = sy1;
                    sc2.Students = new List<Student>();
                    sc2.Students.Add(student4);
                    sc2.Courses = new List<TeacherTeachesCourse>();
                    sc2.Courses.Add(tts1);
                    sc2.Courses.Add(tts3);
                    sc.Add(sc2);
                    

                    SchoolClass sc3 = new SchoolClass();
                    sc3.Grade = Grade.SEVENTH;
                    sc3.Section = "A";
                    sc3.SchoolYear = sy1;
                    sc3.Students.Add(student1);
                    sc3.Students.Add(student2);
                    sc3.Students.Add(student3);
                    sc3.Courses.Add(tts2);
                    sc3.Courses.Add(tts4);
                    sc.Add(sc3);
                    

                    foreach (SchoolClass sc0 in sc)
                        context.SchoolClasses.Add(sc0);
                    base.Seed(context);

                    /*
                    student5.SchoolClass = sc1;
                    student4.SchoolClass = sc2;
                    student1.SchoolClass = sc3;
                    student2.SchoolClass = sc3;
                    student3.SchoolClass = sc3;
                    base.Seed(context);
                    */

                    //student takes course
                    IList<StudentTakesCourse> studentTakesCourses = new List<StudentTakesCourse>();

                    StudentTakesCourse shs1 = new StudentTakesCourse();
                    shs1.Student = student1;
                    shs1.Course = tts2;
                    studentTakesCourses.Add(shs1);
                   

                    StudentTakesCourse shs2 = new StudentTakesCourse();
                    shs2.Student = student1;
                    shs2.Course = tts4;
                    studentTakesCourses.Add(shs2);

                    StudentTakesCourse shs3 = new StudentTakesCourse();
                    shs3.Student = student4;
                    shs3.Course = tts1;
                    studentTakesCourses.Add(shs3);

                    StudentTakesCourse shs4 = new StudentTakesCourse();
                    shs4.Student = student4;
                    shs4.Course = tts4;
                    studentTakesCourses.Add(shs4);

                    foreach (StudentTakesCourse shs0 in studentTakesCourses)
                        context.StudentTakesCourse.Add(shs0);

                    List<StudentTakesCourse> student1Courses = new List<StudentTakesCourse>();
                    student1Courses.Add(shs1);
                    student1Courses.Add(shs2);
                    student1.StudentTakesCourses = student1Courses;

                    List<StudentTakesCourse> student4Courses = new List<StudentTakesCourse>();
                    student4Courses.Add(shs3);
                    student4Courses.Add(shs4);
                    student4.StudentTakesCourses = student4Courses;

                    context.Students.Attach(student1);
                    context.Students.Attach(student4);
                    context.SaveChanges();
                    base.Seed(context);


                    //marks
                    IList<Mark> marks = new List<Mark>();

                    Mark m1 = new Mark();
                    //m1.Student_Course = shs1;
                    m1.Value = StudentMark.INSUFFICIENT;
                    m1.DateAdded = new DateTime(2019, 1, 25);
                    marks.Add(m1);

                    Mark m2 = new Mark();
                   //m2.Student_Course = shs1;
                    m2.Value = StudentMark.BELOW_AVERAGE;
                    m2.DateAdded = new DateTime(2019, 1, 15);
                    marks.Add(m2);

                    Mark m3 = new Mark();
                    //m3.Student_Course = shs3;
                    m3.Value = StudentMark.ABOVE_AVERAGE;
                    m3.DateAdded = new DateTime(2018, 12, 14);
                    marks.Add(m3);

                    foreach (Mark mark in marks)
                        context.Marks.Add(mark);
                    base.Seed(context);

                    shs1.StudentsMarksFromCourse.Add(m1);
                    shs1.StudentsMarksFromCourse.Add(m2);
                    shs3.StudentsMarksFromCourse.Add(m3);
                    base.Seed(context);

                }

            }

            context.SaveChanges();

        }
    }
}