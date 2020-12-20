#include "Error.h"
namespace Error
{

	ERROR errors[ERROR_MAX_ENTRY] =
	{
	ERROR_ENTRY(0,"Недопустимый код ошибки"),
	ERROR_ENTRY(1,"Системный сбой"),
	ERROR_ENTRY_NODEF(2),
	ERROR_ENTRY_NODEF(3),
	ERROR_ENTRY_NODEF(4),
	ERROR_ENTRY_NODEF(5),
	ERROR_ENTRY_NODEF(6),
	ERROR_ENTRY_NODEF(7),
	ERROR_ENTRY_NODEF(8),
	ERROR_ENTRY_NODEF(9),
	ERROR_ENTRY_NODEF10(10),
	ERROR_ENTRY_NODEF10(20),
	ERROR_ENTRY_NODEF10(30),
	ERROR_ENTRY_NODEF10(40),
	ERROR_ENTRY_NODEF10(50),
	ERROR_ENTRY_NODEF10(60),
	ERROR_ENTRY_NODEF10(70),
	ERROR_ENTRY_NODEF10(80),
	ERROR_ENTRY_NODEF10(90),
	ERROR_ENTRY(100, "парамет -in должен быть задан"),
	ERROR_ENTRY_NODEF(101),
	ERROR_ENTRY_NODEF(102),
	ERROR_ENTRY_NODEF(103),
	ERROR_ENTRY(104, "превышена длина входного параметра"),
	ERROR_ENTRY_NODEF(105),
	ERROR_ENTRY_NODEF(106),
	ERROR_ENTRY_NODEF(107),
	ERROR_ENTRY_NODEF(108),
	ERROR_ENTRY_NODEF(109),
	ERROR_ENTRY(110,"ошибка открытия файла с исходным кодом (-in)"),
	ERROR_ENTRY_NODEF(111),
	ERROR_ENTRY(112,"ошибка создания файла потока (-log)"),
	ERROR_ENTRY(113,"ошибка открытия файла библиотеки"),
	ERROR_ENTRY_NODEF(114),
	ERROR_ENTRY_NODEF(115),
	ERROR_ENTRY_NODEF(116),
	ERROR_ENTRY_NODEF(117),
	ERROR_ENTRY_NODEF(118),
	ERROR_ENTRY_NODEF(119),
	ERROR_ENTRY(120, "Цепочка не распознана"),
	ERROR_ENTRY(121, "недопустимый символ в исходном файле"),
	ERROR_ENTRY(122,"текст после главной функции"),
	ERROR_ENTRY(123,"ошибка:присутствует неопознанный текст"),
	ERROR_ENTRY_NODEF(124),
	ERROR_ENTRY_NODEF(125),
	ERROR_ENTRY_NODEF(126),
	ERROR_ENTRY(127,"не совпадает количество закрывающих и открывающих фигурных скобок"),
	ERROR_ENTRY(128,"Попытка повторного подключения библиотеки"),
	ERROR_ENTRY(129,"Отсутствует библиотека ввода/вывода IoLibrary"),
	ERROR_ENTRY(130,"Ошибка создания таблицы итендификаторов: размер превышает допустимое значение"),
	ERROR_ENTRY(131,"Ошибка создания таблицы литералов: размер превышает допустимое значение"),
	ERROR_ENTRY(132,"Ошибка добавления в таблицу лексем: превышен макимальный размер таблицы"),
	ERROR_ENTRY(133,"Ошибка добавления в таблицу итендификаторов: превышен макимальный размер таблицы"),
	ERROR_ENTRY(134,"Ошибка получения элемента из таблицы итендификаторов: элемент не создан или индекс выходит за границы массива"),
	ERROR_ENTRY(135,"Ошибка получения элемента из таблицы литералов: элемент не создан или индекс выходит за границы массива"),
	ERROR_ENTRY(136,"Ошибка:переопределение функции"),
	ERROR_ENTRY(137,"Ошибка:переопределение идентификатора"),
	ERROR_ENTRY(138,"Ошибка:отсутствует идентификатор функции"),
	ERROR_ENTRY(139,"Отсутсвует закрывающий символ"),
	ERROR_ENTRY_NODEF10(140),
	ERROR_ENTRY_NODEF10(150),
	ERROR_ENTRY_NODEF10(160),
	ERROR_ENTRY_NODEF10(170),
	ERROR_ENTRY_NODEF10(180),
	ERROR_ENTRY_NODEF10(190),
	ERROR_ENTRY_NODEF100(200),
	ERROR_ENTRY(300,"Не совпадение типов параметров функции"),
	ERROR_ENTRY(301,"Не совпадение количества параметров,передаваемых в функцию"),
	ERROR_ENTRY(302,"Присвоение не соотвествующего типа"),
	ERROR_ENTRY(303,"Попытка произвести операцию над строкой"),
	ERROR_ENTRY(304,"Операции над разными типами"),
	ERROR_ENTRY_NODEF(305),
	ERROR_ENTRY(306,"Вызов несущсетвующей функции"),
	ERROR_ENTRY(307,"Не совпадение формального возвращающегося типа с фактическим"),
	ERROR_ENTRY(308,"Целочисленное переполнение литерала"),
	ERROR_ENTRY(309,"Строковое	переполнение литерала"),
	ERROR_ENTRY(310,"Попытка деления на 0"),
	ERROR_ENTRY(311,"неверный параметр цикла"),
	ERROR_ENTRY(312,"ошибка разбора выражения"),
	ERROR_ENTRY(313,"попытка изменить литерал"),
	ERROR_ENTRY(314, "Недостаточное количество передаваемых во внешнюю функцию параметров"),
	ERROR_ENTRY(315, "Передаваемые во внешюю функцию параметры не совпадают с необходимыми"),
	ERROR_ENTRY(316, "Избыток передаваемых во внешнюю фунецию параметров"),
	ERROR_ENTRY(317, "Не соответствие количества формальных и фактических параметров"),
	ERROR_ENTRY_NODEF(318),
	ERROR_ENTRY_NODEF(319),
	ERROR_ENTRY_NODEF10(320),
	ERROR_ENTRY_NODEF10(330),
	ERROR_ENTRY_NODEF10(340),
	ERROR_ENTRY_NODEF10(350),
	ERROR_ENTRY_NODEF10(360),
	ERROR_ENTRY_NODEF10(370),
	ERROR_ENTRY_NODEF10(380),
	ERROR_ENTRY_NODEF10(390),
	ERROR_ENTRY_NODEF100(400),
	ERROR_ENTRY_NODEF100(500),
	ERROR_ENTRY(600, "Неверная структура программы"),
	ERROR_ENTRY(601, "Ошибка в конструкции в функции"),
	ERROR_ENTRY(602, "Ошибка в выражении"),
	ERROR_ENTRY(603, "Ошибка в формальных параметрах функции"),
	ERROR_ENTRY(604, "Ошибка в фактических параметрах  функции "),
	ERROR_ENTRY(605, "Ошибка в операторе"),
	ERROR_ENTRY_NODEF(606),
	ERROR_ENTRY_NODEF(607),
	ERROR_ENTRY_NODEF(608),
	ERROR_ENTRY_NODEF(609),
	ERROR_ENTRY_NODEF10(610),
	ERROR_ENTRY_NODEF10(620),
	ERROR_ENTRY_NODEF10(630),
	ERROR_ENTRY_NODEF10(640),
	ERROR_ENTRY_NODEF10(650),
	ERROR_ENTRY_NODEF10(660),
	ERROR_ENTRY_NODEF10(670),
	ERROR_ENTRY_NODEF10(680),
	ERROR_ENTRY_NODEF10(690),
	ERROR_ENTRY_NODEF100(700),
	ERROR_ENTRY_NODEF100(800),
	ERROR_ENTRY_NODEF100(900),
	};
	ERROR geterror(int id)
	{
		ERROR out;

		if (0 > id || id > ERROR_MAX_ENTRY)
			out = errors[0];
		else
			out = errors[id];
		return out;
	}
	ERROR geterrorin(int id, int line = -1, int col = -1)
	{
		ERROR out;

		if (0 > id || id > ERROR_MAX_ENTRY)
			out = errors[0];
		else
			out = errors[id];
		out.inext.line = line;
		out.inext.col = col;
		return out;
	}

}