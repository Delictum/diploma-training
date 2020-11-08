-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Сен 20 2017 г., 21:45
-- Версия сервера: 5.5.53
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Laba8`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Stud`
--

CREATE TABLE `Stud` (
  `ID` int(11) NOT NULL,
  `Fam` varchar(255) NOT NULL,
  `Im` varchar(255) NOT NULL,
  `Ot` varchar(255) NOT NULL,
  `Ocenka` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Stud`
--

INSERT INTO `Stud` (`ID`, `Fam`, `Im`, `Ot`, `Ocenka`) VALUES
(1, 'Андрейчик', 'Игорь', 'Владимирович', 5),
(2, 'Зелень', 'Стас', 'Жданович', 2),
(3, 'Сафа', 'Аня', 'Ольгердовна', 3),
(4, 'Сента', 'Оля', 'Дмитриевна', 5),
(5, 'Зольта', 'Катерина', 'Владиславовна', 5),
(6, 'Аргентова', 'Ирина', 'Вячеславовна', 5),
(7, 'Головач', 'Маргарита', 'Евгеньевна', 5),
(8, 'Золтан', 'Лютик', 'Андреевич', 1),
(9, 'Шагдай', 'Максим', 'Иванович', 2),
(10, 'Якутенко', 'Ярослав', 'Францович', 3),
(11, 'Шубченко', 'Антон', 'Генадьевич', 1),
(12, 'Манцевич', 'Даниил', 'Николаевич', 0),
(13, 'Иванов', 'Сидр', 'Семенович', 0),
(14, 'Персунова', 'Славяна', 'Игоревна', 4),
(15, 'Альбедо', 'Святослав', 'Чеславович', 3),
(16, 'Славинский', 'Артур', 'Артемоич', 0),
(17, 'Сноу', 'Антуа', 'Филиппович', 0),
(18, 'Байрон', 'Келлай', 'Свидригайловна', 2),
(19, 'Чертов', 'Александр', 'Сергеевич', 0),
(20, 'Магнолис', 'Филиция', 'Германовна', 4);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Stud`
--
ALTER TABLE `Stud`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Stud`
--
ALTER TABLE `Stud`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
