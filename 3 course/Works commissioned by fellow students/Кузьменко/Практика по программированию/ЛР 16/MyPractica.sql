-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 06 2018 г., 10:58
-- Версия сервера: 5.6.38
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `MyPractica`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Objects`
--

CREATE TABLE `Objects` (
  `ID` int(11) NOT NULL,
  `CodeO` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Lections` int(11) NOT NULL,
  `Practics` int(11) NOT NULL,
  `Labs` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Objects`
--

INSERT INTO `Objects` (`ID`, `CodeO`, `Name`, `Lections`, `Practics`, `Labs`) VALUES
(1, 11, 'Литература', 80, 30, 40),
(3, 2, '2', 2, 2, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `Plan`
--

CREATE TABLE `Plan` (
  `ID` int(11) NOT NULL,
  `CodeS` int(11) NOT NULL,
  `CodeO` int(11) NOT NULL,
  `Ocenka` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Plan`
--

INSERT INTO `Plan` (`ID`, `CodeS`, `CodeO`, `Ocenka`) VALUES
(2, 11, 11, 9),
(3, 1, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Students`
--

CREATE TABLE `Students` (
  `ID` int(11) NOT NULL,
  `CodeS` int(11) NOT NULL,
  `FIO` varchar(255) NOT NULL,
  `Adress` varchar(255) NOT NULL,
  `Telephone` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Students`
--

INSERT INTO `Students` (`ID`, `CodeS`, `FIO`, `Adress`, `Telephone`) VALUES
(1, 20, 'Абдыл', 'Гродно, Тавлая 1-1', '80331111111'),
(2, 11, 'Крушевский Н.Н.', 'Гродно, Троицкая 1-1', '80332222222');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Objects`
--
ALTER TABLE `Objects`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `Plan`
--
ALTER TABLE `Plan`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `Students`
--
ALTER TABLE `Students`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Objects`
--
ALTER TABLE `Objects`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Plan`
--
ALTER TABLE `Plan`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Students`
--
ALTER TABLE `Students`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
