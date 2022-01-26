
--- Her devamsýzlýk güncellendiðinde baþarý notuda güncellenecek-- 
ALTER Trigger UpdateStudentSuccessStatusWeekly
on StudentAttendance 
after update
as 
begin
	DECLARE @CourseId INT;
	DECLARE @InscriptionDate smalldatetime;
	DECLARE @Duration tinyint;
	DECLARE @StudentId	INT;
	DECLARE @SuccessStatus FLOAT;
	DECLARE @Attendance tinyint;
	SELECT @StudentId =StudentId from inserted;
	SELECT @CourseId = CourseId from CourseStudents where StudentId =@StudentId;
	SELECT @Duration = Duration from Courses where CourseId =@CourseId;
	SELECT @Attendance = Attendance from inserted;
	SET @SuccessStatus = CAST(@Attendance as float)/CAST(@Duration as float)
	update StudentSuccess set SuccessStatus=@SuccessStatus where StudentId=@StudentId
end



go
Update StudentAttendance set Attendance =5 where StudentId=5
go
