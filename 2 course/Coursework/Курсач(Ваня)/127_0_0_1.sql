-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 20 2017 г., 04:52
-- Версия сервера: 5.5.53
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `kursach`
--
CREATE DATABASE IF NOT EXISTS `kursach` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `kursach`;

-- --------------------------------------------------------

--
-- Структура таблицы `задания`
--

CREATE TABLE `задания` (
  `id_zadanie` int(11) NOT NULL,
  `задача` longtext COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `задания`
--

INSERT INTO `задания` (`id_zadanie`, `задача`) VALUES
(0, 'Для каждого из углов 10◦, 30◦, 60◦ найдите приближенные значения синуса и радианной меры (с двумя значащими цифрами). На сколько процентов отличаются синус и радианная\r\nмера для этих углов?\r\nЗадача 1.3. Пусть радианная мера острого угла равна α. Дока-\r\nжите неравенство: sin α < α (словами: синус острого угла меньшеего радианной меры).');

-- --------------------------------------------------------

--
-- Структура таблицы `glavi`
--

CREATE TABLE `glavi` (
  `id` int(100) NOT NULL,
  `soderz` varchar(100) NOT NULL,
  `soderz2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Дамп данных таблицы `glavi`
--

INSERT INTO `glavi` (`id`, `soderz`, `soderz2`) VALUES
(1, 'введение', 'Что такое тригонометрия? Скучные и никому не нужные форму-\r\nлы — скажут почти все старшеклассники. Тем не менее, мы хотим\r\nвас в этом разубедить.\r\nЧтобы взглянуть на тригонометрию по-новому, мы рассказы-\r\nваем о ней «с нуля». Поэтому читать пособие лучше с самого\r\nначала и подряд, хотя кое-что вы, скорее всего, уже знаете.\r\nНаши определения равносильны определениям из школьных\r\nучебников, но не всегда дословно с ними совпадают.\r\nНе надо стремиться перерешать все задачи из книги (мы со-\r\nзнательно поместили их с запасом), но сколько-то задач после\r\nкаждого параграфа порешать стоит. Если задачи к параграфу\r\nсовсем не выходят, значит, что-то вы не усвоили, и есть смысл\r\nперечитать этот параграф.\r\nБолее трудные задачи отмечены звездочкой, более трудный\r\nтекст напечатан мелким шрифтом. При первом чтении все это\r\nможно пропустить.\r\nТеперь более подробно о содержании книги. В первых двух\r\nглавах речь идет о начальных понятиях тригонометрии (точнее\r\nговоря, о той ее части, в которой не участвуют формулы сложе-\r\nния). Третья глава («Решение треугольников») посвящена при-\r\nменениям тригонометрии к планиметрии. (Имейте в виду, что\r\nрешение треугольников — не единственный раздел геометрии; не\r\nследует думать, что, проработав только нашу книжку, вы уже\r\nнаучитесь решать геометрические задачи.)\r\nЧетвертая глава посвящена формулам сложения и их след-\r\nствиям. Это — центральная часть тригонометрии (и книги), и имен-\r\nно здесь сосредоточены основные тригонометрические формулы.\r\nМы надеемся, что после изучения этой главы вы поймете, откуда\r\nони берутся, и научитесь в них ориентироваться. Мы начина-\r\nем эту главу с параграфов, в которых рассказано о векторах на\r\nплоскости, а сами тригонометрические формулы иллюстрируем\r\nпримерами из физики.\r\n'),
(2, 'информация', 'Древнегреческие математики в своих построениях, связанных с измерением дуг круга, использовали технику хорд. Перпендикуляр к хорде, опущенный из центра окружности, делит пополам дугу и опирающуюся на неё хорду. Половина поделенной пополам хорды — это синус половинного угла, и поэтому функция синус известна также как «половина хорды». Благодаря этой зависимости, значительное число тригонометрических тождеств и теорем, известных сегодня, были также известны древнегреческим математикам, но в эквивалентной хордовой форме. Хотя в работах Евклида и Архимеда нет тригонометрии в строгом смысле этого слова, их теоремы представлены в геометрическом виде, эквивалентном специфическим тригонометрическим формулам. Теорема Архимеда для деления хорд эквивалентна формулам для синусов суммы и разности углов. Для компенсации отсутствия таблицы хорд математики времен Аристарха иногда использовали хорошо известную теорему, в современной записи — sinα/sinβ < α/β < tgα/tgβ, где 0° < β < α < 90°, совместно с другими теоремами.\r\n\r\nПервые тригонометрические таблицы были, вероятно, составлены Гиппархом Никейским (180—125 лет до н. э.). Гиппарх был первым, кто свёл в таблицы соответствующие величины дуг и хорд для серии углов. Систематическое использование полной окружности в 360° установилось в основном благодаря Гиппарху и его таблице хорд. Возможно Гиппарх взял идею такого деления у Гипсикла, который ранее разделил день на 360 частей, хотя такое деление дня могли предложить и вавилонские астрономы.'),
(3, 'формулы', ''),
(4, 'glavi', '');

-- --------------------------------------------------------

--
-- Структура таблицы `paragraf`
--

CREATE TABLE `paragraf` (
  `id` int(100) NOT NULL,
  `параграф` longtext CHARACTER SET utf8 NOT NULL,
  `id_zadanie` int(100) NOT NULL,
  `id_formula` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `paragraf`
--

INSERT INTO `paragraf` (`id`, `параграф`, `id_zadanie`, `id_formula`) VALUES
(1, 'Пусть человек поднимается в гору. Будем считать, что склон горы — это гипотенуза AB прямоугольного треугольника ABC (рис. 1.1).Можно предложить по крайней мере два способа измерения крутизны подъема: 1) измерить высоту подъема (отрезок BC на рис. 1.1а);\r\n2) провести дугу с центром в точке (рис. 1.1б) и измерить ее длину.\r\nКонечно, сама по себе высота подъема ничего не характеризует: если вы долго идете по склону, то можно подняться высоко даже при пологом склоне. Поэтому нужно рассматривать отношение длины подъема к длине пути (соответственно отношение длины дуги к радиусу Эти отношения от длины пути уже не зависят.Вот формальное доказательство того, что отношение длины подъема к длине\r\nпути не зависит от этой длины. Пусть человек прошел не весь путь, а дошел только до точки B0(рис. 1.2). Тогда крутизна подъема на отрезке AB0 равна B0C0/A0B0, а на отрезке AB равна BC/AB.Определение. Синусом острого угла в прямоугольном треугольнике называется отношение катета этого треугольника, лежащего против угла, к гипотенузе треугольника Вторая из введенных нами характеристик крутизны называется\r\nрадианной мерой угла.\r\nОпределение. Радианной мерой угла называется отношение\r\nдлины дуги окружности, заключенной между сторонами угла и\r\nс центром в вершине угла, к радиусу этой окружности (рис. 1.4).\r\n\r\n\r\n', 0, 1),
(3, 'фцвфцв', 0, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `risunki`
--

CREATE TABLE `risunki` (
  `id_formula` int(100) NOT NULL,
  `formuli` longtext COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `risunki`
--

INSERT INTO `risunki` (`id_formula`, `formuli`) VALUES
(1, '1231243445346');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `задания`
--
ALTER TABLE `задания`
  ADD PRIMARY KEY (`id_zadanie`),
  ADD KEY `id_zadanie` (`id_zadanie`),
  ADD KEY `id_zadanie_2` (`id_zadanie`),
  ADD KEY `id_zadanie_3` (`id_zadanie`);

--
-- Индексы таблицы `glavi`
--
ALTER TABLE `glavi`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `paragraf`
--
ALTER TABLE `paragraf`
  ADD PRIMARY KEY (`id`),
  ADD KEY `paragraf_ibfk_1` (`id_zadanie`),
  ADD KEY `id_formula` (`id_formula`);

--
-- Индексы таблицы `risunki`
--
ALTER TABLE `risunki`
  ADD PRIMARY KEY (`id_formula`),
  ADD KEY `id_picture` (`id_formula`),
  ADD KEY `id_formula` (`id_formula`),
  ADD KEY `id_formula_2` (`id_formula`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `задания`
--
ALTER TABLE `задания`
  MODIFY `id_zadanie` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `glavi`
--
ALTER TABLE `glavi`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT для таблицы `paragraf`
--
ALTER TABLE `paragraf`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `risunki`
--
ALTER TABLE `risunki`
  MODIFY `id_formula` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `paragraf`
--
ALTER TABLE `paragraf`
  ADD CONSTRAINT `paragraf_ibfk_1` FOREIGN KEY (`id_zadanie`) REFERENCES `задания` (`id_zadanie`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `paragraf_ibfk_2` FOREIGN KEY (`id_formula`) REFERENCES `risunki` (`id_formula`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
