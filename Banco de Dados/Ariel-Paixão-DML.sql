use Ariel_Paixao_LanHouseSAEP;

insert into Usuarios	(Email, Senha)
values					('admin@admin.com', 'admin')

bulk insert TiposDefeitos
	from 'C:\lanhouse\defeito.csv'
		with(
			format = 'csv',
			firstrow = 1,
			fieldterminator= ';',
			rowterminator = '\n',
			codepage = 'ACP',
			datafiletype = 'Char'
		);

bulk insert TiposEquipamentos
	from 'C:\lanhouse\tipo_equipamento.csv'
		with(
			format = 'csv',
			firstrow = 1,
			fieldterminator= ';',
			rowterminator = '\n',
			codepage = 'ACP',
			datafiletype = 'Char'
		);

bulk insert RegistroDefeitos
	from 'C:\lanhouse\registro_defeito.csv'
		with(
			format = 'csv',
			firstrow = 1,
			fieldterminator= ';',
			rowterminator = '\n',
			codepage = 'ACP',
			datafiletype = 'Char'
		);

BACKUP DATABASE Ariel_Paixao_LanHouseSAEP
	TO DISK = 'C:\lanhouse\Ariel-Paixao-LanHouseSAEP-DB.BAK'