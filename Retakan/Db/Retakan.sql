CREATE DATABASE Retakan
USE Retakan

CREATE TABLE DataGempa(
id_gempa int CONSTRAINT pk_gempa PRIMARY KEY not null IDENTITY(1,1),
gempa char(5),
tempat text not null,
waktu datetime,
tsunami char(50)
)
Select * FROM DataGempa
ALTER TABLE DataGempa ADD id_gempa INT IDENTITY(1,1)

INSERT INTO DataGempa VALUES('3.5','England','12/16/2016 13:50:40','0')

ALTER TABLE DataGempa	
ALTER COLUMN waktu datetime

ALTER TABLE DataGempa	
ALTER COLUMN tsunami char(17)

INSERT INTO DataGempa VALUES('3.3','67km NE of Road Town, British Virgin Islands','12/16/2016 13:50:40','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('0.24','2km ESE of Mammoth Lakes, California','12/18/2016 3:11:17','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('2.34','16km NE of Arlington Heights, Washington','12/21/2016 10:18:26','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('1.77','9km W of Cobb, California','12/21/2016 10:13:00','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('4.9','71km S of Acajutla, El Salvador','12/21/2016 3:08:09','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('3.15','10km NNE of Ocotillo Wells, CA','12/21/2016 3:11:04','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('5.1','114km SE of Honiara, Solomon Islands','12/21/2016 6:22:02','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('4.4','162km NW of Farallon de Pajaros, Northern Mariana Islands','12/9/2016 1:14:38','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('4.9','72km W of Kirakira, Solomon Islands','12/16/2016 13:50:40','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('4.6','36km ENE of Suao, Taiwan','12/9/2016 11:09:47','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('5.1','93km WSW of Kirakira, Solomon Islands','12/9/2016 9:46:12','Tidak Berpotensi')
INSERT INTO DataGempa VALUES('4.8','87km SW of Kirakira, Solomon Islands','12/9/2016 8:31:41','Tidak Berpotensi')

Delete DataGempa
select * from DataGempa