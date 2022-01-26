

 --Stored procedure yazýn
 -- Ögrencileri egitimlere ekleyen bir procedure olacak. ogrenci belirtilen egitim tarihinde herhangi baþka bir egitime kayýtlý olmamalýdýr.

 ----- Create Store Procedure--------
 -- create proc SP_RegisterNewStudent(@StudentId int,@CourseId int ,@InscriptionDate smalldatetime)
 --as
 --begin
	
	--declare @check bit;
	--declare @AlreadyRegistered int;
	--select @AlreadyRegistered = CourseId from CourseStudents
	--where InscriptionDate = @InscriptionDate and StudentId=@StudentId;
	--if(@AlreadyRegistered>0)
	--	begin
	--		raiserror('Already registered an other course',1,1);
	--	end
	--else
	--	begin
	--	 insert into CourseStudents (StudentId,CourseId,InscriptionDate) values (@StudentId,@CourseId,@InscriptionDate);
	--	end
 --end


 ------ Alter Store Proc------------

alter proc SP_RegisterNewStudent(@StudentId int,@CourseId int ,@InscriptionDate smalldatetime)
 as
 begin
	
	declare @check bit;
	declare @AlreadyRegistered int;
	select @AlreadyRegistered = CourseId from CourseStudents
	where InscriptionDate = @InscriptionDate and StudentId=@StudentId;
	if(@AlreadyRegistered>0)
		begin
			raiserror('Already registered an other course',1,1);
		end
	else
		begin
		 insert into CourseStudents (StudentId,CourseId,InscriptionDate) values (@StudentId,@CourseId,@InscriptionDate);
		end
 end

 exec SP_RegisterNewStudent 14, 2, '2025-12-21 12:40:53'