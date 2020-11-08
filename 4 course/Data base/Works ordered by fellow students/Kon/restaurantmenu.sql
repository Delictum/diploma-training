-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 11 2019 г., 14:16
-- Версия сервера: 8.0.12
-- Версия PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `restaurantmenu`
--

-- --------------------------------------------------------

--
-- Структура таблицы `menu`
--

CREATE TABLE `menu` (
  `Id` int(11) NOT NULL,
  `Date` date NOT NULL,
  `NameDishId` int(11) NOT NULL,
  `TypeDishId` int(11) NOT NULL,
  `Cost` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  `VAT` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `menu`
--

INSERT INTO `menu` (`Id`, `Date`, `NameDishId`, `TypeDishId`, `Cost`, `Count`, `VAT`) VALUES
(1, '2019-01-11', 1, 1, 32, 2, 1),
(2, '2019-01-10', 1, 2, 12, 4, 1),
(3, '2019-01-09', 2, 1, 1, 70, 0),
(4, '2019-01-12', 3, 3, 1, 3, 0),
(5, '2019-01-11', 1, 1, 12, 4, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `namedish`
--

CREATE TABLE `namedish` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `namedish`
--

INSERT INTO `namedish` (`Id`, `Name`) VALUES
(1, 'Magic wand'),
(2, 'Falling sky'),
(3, 'Richest rush');

-- --------------------------------------------------------

--
-- Структура таблицы `typedish`
--

CREATE TABLE `typedish` (
  `Id` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `typedish`
--

INSERT INTO `typedish` (`Id`, `Type`) VALUES
(1, 'Hot'),
(2, 'Cold'),
(3, 'Snack');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `namedish`
--
ALTER TABLE `namedish`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `typedish`
--
ALTER TABLE `typedish`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `menu`
--
ALTER TABLE `menu`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `namedish`
--
ALTER TABLE `namedish`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `typedish`
--
ALTER TABLE `typedish`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
