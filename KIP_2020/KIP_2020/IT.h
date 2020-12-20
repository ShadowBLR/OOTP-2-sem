#pragma once
#define TI_AREA_SIZE	10
#define ID_MAXSIZE		10 //���� ���-�� �������� � �������
#define	TI_MAXSIZE		4096 //���� ���-�� ����� � ���� ���������������
#define TI_INT_DEFAULT	0x00000000	//�������� int �� �������
#define	TI_STR_DEFAULT	0x00		//�������� string �� �������
#define	TI_NULLIDX		0xffffffff	//��� �������� ������� ���������������
#define	TI_STR_MAXSIZE	255

namespace IT	//������� ���������������
{
	enum IDDATATYPE { DEF = 0, INT = 1, STR = 2 ,EINT,ESHORT,ECHAR,ESTRING};//������� ������ ���������������
	enum IDTYPE { V = 1, F = 2, P = 3, L = 4, N=5,LIB=6 ,EF,EP};//���� ��������������� - ���������� ������� �������� �������,no def,library

	struct Entry //������ ������� ���������������
	{
		int idxfirstLE; //������ ������ ������ � ������� ������
		char* areaOfvisibility = nullptr;
		char id[ID_MAXSIZE]; //�������������
		IDDATATYPE iddatatype = IDDATATYPE::DEF; //��� ������
		IDTYPE idtype = IDTYPE::N; //��� ��������������

		union {
			int vint; //�������� integer
			struct
			{
				char len;//���-�� �������� � string
				char str[TI_STR_MAXSIZE - 1];//������� ������
			} vstr;//�������� sting
		} value; //�������� ��������������
	};

	struct IdTable		//��������� ������� ��
	{
		int maxsize;	//������� �������
		int size;		//������� ������
		Entry* table;	//������ ����� ������� ���������������
		IdTable* externTable;
	};
	IdTable Create(	//������� ������� ID
		int size	//�������
	);
	void Add(
		IdTable& idtable,	//��������� ������� ���������������
		Entry entry		//������ ������� ���������������
	);
	Entry GetEntry(	//�������� ������ ������� ���������������
		IdTable& idtable,	//��������� ������� ���������������
		int n				//������ ������� ���������������
	);
	int IsId(
		IdTable& idtable,	//�������: ����� ������(���� ����) TI_NULLID(���� ���)
		char id[ID_MAXSIZE], //�������������
		char* area
	);
	int IsId(
		IdTable& idtable,	//�������: ����� ������(���� ����) TI_NULLID(���� ���)
		char id[ID_MAXSIZE] //�������������
	);

	void Delete(IdTable& idtable);	//������� ������� ���������������
}