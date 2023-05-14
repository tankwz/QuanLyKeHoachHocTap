use KHHT;
drop table KTPM_K44;

drop table subjects;

drop table students;

drop table studentSubjects;

truncate table studentSubjects;

truncate table students;

select * from studentSubjects;


CREATE TABLE ssubjects (
    --khhtid INT primary key ,
	id NVARCHAR(50) primary key,
	st_id NVARCHAR(8),
    orderz INT,
    count INT ,
    hknamhoc NVARCHAR(50),
    marktext NVARCHAR(50) ,
    mark NVARCHAR(50) ,
    name NVARCHAR(50) ,
    credits INT ,
    get NVARCHAR(50) ,
  --  FOREIGN KEY (st_id) REFERENCES students(st_id)
);

select * from students;

CREATE TABLE students (
  st_id NVARCHAR(8) PRIMARY KEY,
  st_password_hash NVARCHAR(64),
  st_name NVARCHAR(50),
  faculty NVARCHAR(50),
  hk int,
  gpa FLOAT,
);

CREATE TABLE studentSubjects (
    --khhtid INT primary key ,
	id NVARCHAR(50),
	st_id NVARCHAR(8),
    orderz INT ,
    count INT,
    hknamhoc NVARCHAR(50),
    marktext NVARCHAR(50) ,
    mark NVARCHAR(50) ,
    name NVARCHAR(50) ,
    credits INT ,
    get NVARCHAR(50) ,
   FOREIGN KEY (st_id) REFERENCES students(st_id)
);
select * from studentSubjects;
--DELETE FROM studentSubjects WHERE st_id = 121212;
CREATE TABLE studentplan (
    --khhtid INT primary key ,
	id NVARCHAR(50),
	st_id NVARCHAR(8),
    done INT ,
    mark NVARCHAR(50) ,
    name NVARCHAR(50) ,
   FOREIGN KEY (st_id) REFERENCES students(st_id)
);


--select * from students;

drop table ktpm_k44;
drop table subjects;

create table subjects(
	sub_id nvarchar(10) primary key,
	name nvarchar(50),
	credits int,
	prerequisite nvarchar(40)
);

DROP PROCEDURE IF EXISTS addsub; 
GO  
CREATE PROC addsub   
    @id nvarchar(10) = null,   
    @name nvarchar(50)= null,
	@credits int = null,
	@prerequisite nvarchar(40)
AS   											 
SET NOCOUNT ON;
INSERT INTO subjects(sub_id, name, credits, prerequisite)
VALUES (@id, @name, @credits, @prerequisite);
GO 


execute addsub  'QP006', N'Giáo dục quốc phòng – An ninh 1 (*)', '2', N'Sắp sẵn';
execute addsub  'QP007', N'Giáo dục quốc phòng – An ninh 2 (*)', '2', N'Sắp sẵn';
execute addsub  'QP008', N'Giáo dục quốc phòng – An ninh 3 (*)', '3', N'Sắp sẵn';
execute addsub  'QP009', N'Giáo dục quốc phòng – An ninh 4 (*)', '1', N'Sắp sẵn';
execute addsub  'XH023', N'Anh văn căn bản 1 (*)', '4', '';
execute addsub  'XH024', N'Anh văn căn bản 2 (*)', '3', 'XH023';
execute addsub  'XH025', N'Anh văn căn bản 3 (*)', '3', 'XH024';
execute addsub  'XH004', N'Pháp văn căn bản 1 (*)', '3', '';
execute addsub  'XH005', N'Pháp văn căn bản 2 (*)', '3', 'XH004';
execute addsub  'XH006', N'Pháp văn căn bản 3 (*)', '4', 'XH005';
execute addsub  'TN033', N'Tin học căn bản (*)', '1', '';
execute addsub  'TN034', N'TT. Tin học căn bản (*)', '2', '';
execute addsub  'ML009', N'Những nguyên lý cơ bản của CN Mác-Lênin 1', '2', '';
execute addsub  'ML010', N'Những nguyên lý cơ bản của CN Mác-Lênin 2', '3', 'ML009';
execute addsub  'ML006', N'Tư tưởng Hồ Chí Minh', '2', 'ML010';
execute addsub  'ML011', N'Đường lối cách mạng của Đảng Cộng sản Việt Nam', '3', 'ML006';
execute addsub  'KL001', N'Pháp luật đại cương', '2', '';
execute addsub  'ML007', N'Logic học đại cương', '2', '';
execute addsub  'XH028', N'Xã hội học đại cương', '2', '';
execute addsub  'XH011', N'Cơ sở văn hóa Việt Nam', '2', '';
execute addsub  'XH012', N'Tiếng Việt thực hành', '2', '';
execute addsub  'XH014', N'Văn bản và lưu trữ học đại cương', '2', '';
execute addsub  'TN001', N'Vi – Tích phân A1', '3', '';
execute addsub  'TN002', N'Vi – Tích phân A2', '4', 'TN001';
execute addsub  'TN010', N'Xác suất thống kê', '3', '';
execute addsub  'TN012', N'Đại số tuyến tính và hình học', '4', '';
execute addsub  'CT101', N'Lập trình căn bản A', '4', '';
execute addsub  'CT172', N'Toán rời rạc', '4', '';
execute addsub  'CT103', N'Cấu trúc dữ liệu', '4', 'CT101';
execute addsub  'CT173', N'Kiến trúc máy tính', '3', '';
execute addsub  'CT178', N'Nguyên lý hệ điều hành', '3', 'CT173';
execute addsub  'CT179', N'Quản trị hệ thống', '3', '';
execute addsub  'CT112', N'Mạng máy tính', '3', 'CT178';
execute addsub  'CT171', N'Nhập môn công nghệ phần mềm', '3', '';
execute addsub  'CT176', N'Lập trình hướng đối tượng', '3', 'CT101';
execute addsub  'CT175', N'Lý thuyết đồ thị', '3', 'CT103';
execute addsub  'CT311', N'Phương pháp nghiên cứu khoa học', '2', '';
execute addsub  'CT187', N'Nền tảng công nghệ thông tin', '3', '';
execute addsub  'CT183', N'Anh văn chuyên môn CNTT 1', '3', 'XH025';
execute addsub  'CT184', N'Anh văn chuyên môn CNTT 2', '3', 'CT183';
execute addsub  'CT185', N'Pháp văn chuyên môn CNTT 1', '3', 'XH006';
execute addsub  'CT186', N'Pháp văn chuyên môn CNTT 2', '3', 'CT185';
execute addsub  'CT174', N'Phân tích và thiết kế thuật toán', '3', 'CT103';
execute addsub  'CT180', N'Cơ sở dữ liệu', '3', 'CT103';
execute addsub  'CT182', N'Ngôn ngữ mô hình hóa', '3', '';
execute addsub  'CT181', N'Hệ thống thông tin doanh nghiệp', '3', '';
execute addsub  'CT239', N'Niên luận cơ sở ngành KTPM', '3', 'CT174,>= 90TC';
execute addsub  'CT240', N'Nguyên lý xây dựng phần mềm', '3', 'CT171,CT176,CT182';
execute addsub  'CT241', N'Phân tích yêu cầu phần mềm', '3', 'CT171,CT182';
execute addsub  'CT242', N'Kiến trúc và Thiết kế phần mềm', '3', 'CT171';
execute addsub  'CT243', N'Đảm bảo chất lượng và Kiểm thử phần mềm', '4', 'CT171';
execute addsub  'CT244', N'Bảo trì phần mềm', '3', 'CT171';
execute addsub  'CT245', N'Tương tác người máy', '2', 'CT171';
execute addsub  'CT246', N'.NET', '3', 'CT176';
execute addsub  'CT276', N'Java', '3', 'CT176';
execute addsub  'CT223', N'Quản lý dự án phần mềm', '3', 'CT171';
execute addsub  'CT330', N'Hệ thống Multi-Agent', '2', '';
execute addsub  'CT446', N'Ngôn ngữ lập trình mô phỏng', '3', 'CT330';
execute addsub  'CT247', N'Phát triển phần mềm hướng tác tử', '3', 'CT330';
execute addsub  'CT248', N'Kỹ thuật số', '2', '';
execute addsub  'CT234', N'Phát triển phần mềm nhúng', '3', 'CT173';
execute addsub  'CT274', N'Lập trình cho thiết bị di động', '3', 'CT176';
execute addsub  'CT249', N'Phát triển phần mềm tác nghiệp', '2', 'CT181,CT241,CT242';
execute addsub  'CT428', N'Lập trình Web', '3', 'CT176,CT180';
execute addsub  'CT205', N'Quản trị cơ sở dữ liệu', '3', 'CT180';
execute addsub  'CT250', N'Niên luận ngành Kỹ thuật phần mềm', '3', 'CT241,CT242, CT243,CT223';
execute addsub  'CT454', N'Thực tập thực tế - KTPM', '2', 'CT250,>=120TC';
execute addsub  'CT594', N'Luận văn tốt nghiệp - KTPM', '10', '>= 120TC';
execute addsub  'CT464', N'Tiểu luận tốt nghiệp - KTPM', '4', '>= 120TC';
execute addsub  'CT211', N'An ninh mạng', '3', 'CT112';
execute addsub  'CT222', N'An toàn hệ thống', '3', '';
execute addsub  'CT207', N'Phát triển phần mềm mã nguồn mở', '3', 'CT176';
execute addsub  'CT251', N'Phát triển ứng dụng trên Windows', '3', 'CT176, CT180';
execute addsub  'CT206', N'Phát triển ứng dụng trên Linux', '3', 'CT176, CT180';
execute addsub  'CT316', N'Xử lý ảnh', '3', '';
execute addsub  'CT332', N'Trí tuệ nhân tạo', '3', '';
execute addsub  'CT312', N'Khai khoáng dữ liệu', '3', 'TN010';
/*
execute addsub  'TC100', N'Thể chất 1', '1', '';
execute addsub  'TC200', N'Thể chất 2', '1', 'TC100';
execute addsub  'TC300', N'Thế chất 3', '1', 'TC200';
*/
--tc

execute addsub  'TC001', N'Điền kinh 1', '1', '';
execute addsub  'TC002', N'Điền kinh 2', '1', 'TC001';
execute addsub  'TC024', N'Điền kinh 3', '1', 'TC002';

execute addsub  'TC003', N'Taekwondo 1', '1', '';
execute addsub  'TC004', N'Taekwondo 2', '1', 'TC003';
execute addsub  'TC019', N'Taekwondo 3', '1', 'TC004';

execute addsub  'TC005', N'Bóng chuyền 1', '1', '';
execute addsub  'TC006', N'Bóng chuyền 2', '1', 'TC005';
execute addsub  'TC020', N'Bóng chuyền 3', '1', 'TC006';

execute addsub  'TC007', N'Bóng đá 1', '1', '';
execute addsub  'TC008', N'Bóng đá 2', '1', 'TC007';
execute addsub  'TC021', N'Bóng đá 3', '1', 'TC008';

execute addsub  'TC009', N'Bóng bàn 1', '1', '';
execute addsub  'TC010', N'Bóng bàn 2', '1', 'TC009';
execute addsub  'TC022', N'Bóng bàn 3', '1', 'TC010';

execute addsub  'TC011', N'Cầu lông 1', '1', '';
execute addsub  'TC012', N'Cầu lông 2', '1', 'TC011';
execute addsub  'TC023', N'Cầu lông 3', '1', 'TC012';

execute addsub  'TC016', N'Thể dục nhịp điệu 1', '1', '';
execute addsub  'TC017', N'Thể dục nhịp điệu 2', '1', 'TC016';
execute addsub  'TC018', N'Thể dục nhịp điệu 3', '1', 'TC017';

execute addsub  'TC025', N'Cờ vua 1', '1', '';
execute addsub  'TC026', N'Cờ vua 2', '1', 'TC025';
execute addsub  'TC027', N'Cờ vua 3', '1', 'TC026';

execute addsub  'TC013', N'Bơi lội', '1', '';

execute addsub  'TC028', N'Bóng rỗ 1', '1', '';
execute addsub  'TC029', N'Bóng rỗ 2', '1', 'TC028';
execute addsub  'TC030', N'Bóng rỗ 3', '1', 'TC029';


--select * from subjects;

truncate table KTPM_K44;
create table KTPM_K44(
	sub_id nvarchar(10) primary key,
	constraint fk_k_sid FOREIGN KEY (sub_id) REFERENCES subjects(sub_id),
	mandatory nvarchar(10),
	groupz nvarchar(10),
	recommend int,
	opentime int,
)
--select * from subjects;
--select * from KTPM_K44;


DROP PROCEDURE IF EXISTS addktpm44;
GO  
CREATE PROC addktpm44  
    @sub_id nvarchar(10) = null,   
    @mandatory nvarchar(10)= null,
	@groupz nvarchar(10) = null,
	@recommend int = null,
	@opentime int = null
AS   
SET NOCOUNT ON;
INSERT INTO KTPM_K44(sub_id, mandatory, groupz, recommend, opentime)
VALUES (@sub_id, @mandatory, @groupz, @recommend, @opentime);
GO 


execute addktpm44 'QP006', 'all', '',1,0;
execute addktpm44 'QP007', 'all', '',1,0;
execute addktpm44 'QP008', 'all', '',1,0;
execute addktpm44 'QP009', 'all', '',1,0;
execute addktpm44 'XH023', '10', 'NNAV',2,3;
execute addktpm44 'XH024', '10', 'NNAV',4,3;
execute addktpm44 'XH025', '10', 'NNAV',5,3;
execute addktpm44 'XH004', '10', 'NNPV',2,3;
execute addktpm44 'XH005', '10', 'NNPV',4,3;
execute addktpm44 'XH006', '10', 'NNPV',5,3;
execute addktpm44 'TN033', 'all', '',1, 3;
execute addktpm44 'TN034', 'all', '',1, 3;
execute addktpm44 'ML009', 'all', '',2, 3;
execute addktpm44 'ML010', 'all', '', 4,3 ;
execute addktpm44 'ML006', 'all', '',7,3;
execute addktpm44 'ML011', 'all', '', 8,3;
execute addktpm44 'KL001', 'all', '', 7, 3;
execute addktpm44 'ML007', '2', 'XH',4,3;
execute addktpm44 'XH028', '2', 'XH',4,3;
execute addktpm44 'XH011', '2', 'XH',4,3;
execute addktpm44 'XH012', '2', 'XH',4,3;
execute addktpm44 'XH014', '2', 'XH',4,3;
execute addktpm44 'TN001', 'all', '',1,3;
execute addktpm44 'TN002', 'all', '', 4,3;
execute addktpm44 'TN010', 'all', '',4,3;
execute addktpm44 'TN012', 'all', '',2,3;
execute addktpm44 'CT101', 'all', '', 2, 2;
execute addktpm44 'CT172', 'all', '', 2,2;
execute addktpm44 'CT103', 'all', '', 4, 2;
execute addktpm44 'CT173', 'all', '',5,3;
execute addktpm44 'CT178', 'all', '',7,2;
execute addktpm44 'CT179', 'all', '', 11,2;
execute addktpm44 'CT112', 'all', '',8,2;
execute addktpm44 'CT171', 'all', '',5,2;
execute addktpm44 'CT176', 'all', '', 5,2;
execute addktpm44 'CT175', 'all', '',7,2;
execute addktpm44 'CT311', '5', 'N_01',8,2;
execute addktpm44 'CT187', '5', 'N_01',7,2;
execute addktpm44 'CT183', '5', 'N_02',7,2;
execute addktpm44 'CT184', '5', 'N_02',8,2;
execute addktpm44 'CT185', '5', 'N_03',7,2;
execute addktpm44 'CT186', '5', 'N_03',8,2;
execute addktpm44 'CT174', 'all', '', 5,2;
execute addktpm44 'CT180', 'all', '',5,2;
execute addktpm44 'CT182', 'all', '',7,2;
execute addktpm44 'CT181', 'all', '',10,2;
execute addktpm44 'CT239', 'all', '',10,3;
execute addktpm44 'CT240', 'all', '',8,2;
execute addktpm44 'CT241', 'all', '',8,2;
execute addktpm44 'CT242', 'all', '',10,2;
execute addktpm44 'CT243', 'all', '',10,2;
execute addktpm44 'CT244', 'all', '',11,2;
execute addktpm44 'CT245', 'all', '',11,2;
execute addktpm44 'CT246', 'all', '',7,2;
execute addktpm44 'CT276', 'all', '',8,2;
execute addktpm44 'CT223', 'all', '',10,2;
execute addktpm44 'CT330', '8', 'CN01',10,2;
execute addktpm44 'CT446', '8', 'CN01',11,2;
execute addktpm44 'CT247', '8', 'CN01',11,2;
execute addktpm44 'CT248', '8', 'CN02',10,2;
execute addktpm44 'CT234', '8', 'CN02',11,2;
execute addktpm44 'CT274', '8', 'CN02',11,2;
execute addktpm44 'CT249', '8', 'CN03',11,2;
execute addktpm44 'CT428', '8', 'CN03',11,2;
execute addktpm44 'CT205', '8', 'CN03', 10, 2;
execute addktpm44 'CT250', 'all', '',11,3;
execute addktpm44 'CT454', 'all', '',12,1;
execute addktpm44 'CT594', '10', 'TN',13,2;
execute addktpm44 'CT464', '10', 'TN',13,2;
execute addktpm44 'CT211', '10', 'TN',13,2;
execute addktpm44 'CT222', '10', 'TN',13,2;
execute addktpm44 'CT207', '10', 'TN',13,2;
execute addktpm44 'CT251', '10', 'TN',13,2;
execute addktpm44 'CT206', '10', 'TN',13,2;
execute addktpm44 'CT316', '10', 'TN',13,2;
execute addktpm44 'CT332', '10', 'TN',13,2;
execute addktpm44 'CT312', '10', 'TN',13,2;

/*
execute addktpm44 'TC100', '1', 'TC',2,3;
execute addktpm44 'TC200', '1', 'TC',3,2;
execute addktpm44 'TC300', '1', 'TC',4,2;
*/

execute addktpm44  'TC001','3','TCDK',2,3;
execute addktpm44  'TC002','3','TCDK',4,3;
execute addktpm44  'TC024','3','TCDK',5,3;
execute addktpm44  'TC003','3','TCTW',2,3;
execute addktpm44  'TC004','3','TCTW',4,3; 
execute addktpm44  'TC019','3','TCTW',5,3;           
execute addktpm44  'TC005','3','TCBC',2,3;             
execute addktpm44  'TC006','3','TCBC',4,3;         
execute addktpm44  'TC020','3','TCBC',5,3;             
execute addktpm44  'TC007','3','TCBD',2,3;            
execute addktpm44  'TC008','3','TCBD',4,3;          
execute addktpm44  'TC021','3','TCBD',5,3;           
execute addktpm44  'TC009','3','TCBB',2,3;          
execute addktpm44  'TC010','3','TCBB',4,3;          
execute addktpm44  'TC022','3','TCBB',5,3;              
execute addktpm44  'TC011','3','TCCL',2,3;           
execute addktpm44  'TC012','3','TCCL',4,3;          
execute addktpm44  'TC023','3','TCCL',5,3;          
execute addktpm44  'TC016','3','TCND',2,3;              
execute addktpm44  'TC017','3','TCND',4,3;
execute addktpm44  'TC018','3','TCND',5,3;
execute addktpm44  'TC025','3','TCCV',2,3;
execute addktpm44  'TC026','3','TCCV',4,3;
execute addktpm44  'TC027','3','TCCV',5,3;
execute addktpm44  'TC013','3','TCBL',2,3;
execute addktpm44  'TC028','3','TCBR',2,3;
execute addktpm44  'TC029','3','TCBR',4,3;
execute addktpm44  'TC030','3','TCBR',5,3;


DROP PROCEDURE IF EXISTS addsub; 
GO  
CREATE PROC addsub   
    @id nvarchar(10) = null,   
    @name nvarchar(30)= null,
	@credits int = null   
AS   
SET NOCOUNT ON;
INSERT INTO subjects(sub_id, name, credits)
VALUES (@id, @name, @credits);
GO 

select KTPM_K44.sub_id, name, credits, prerequisite, mandatory, groupz,recommend, opentime from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id;



select COUNT(*) from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id;
