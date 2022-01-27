
-- 1. Created OrderByCourseId view
-- 2. Created ListStudentDetails view, used inner join 

------1----------
--Create View OrderByCourseId as
--select CourseStudents.StudentId,CourseStudents.CourseId,CourseStudents.InscriptionDate from CourseStudents
--order by CourseStudents.CourseId OFFSET 0 ROWS

-- Query the view
-- select * from OrderByCourseId;

------2----------

--Create View ListStudentDetails
--as 
--select Students.StudentId,CourseStudents.InscriptionDate,CourseStudents.CourseId,Students.FirstName,Students.LastName,Students.Email,Students.Description from CourseStudents 
--inner join Students
--on
--Students.StudentId=CourseStudents.StudentId
--order by CourseStudents.CourseId 
--OFFSET 0 ROWS;

-- Query the view
 --select * from ListStudentDetails;