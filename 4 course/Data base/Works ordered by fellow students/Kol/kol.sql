-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 14 2019 г., 21:51
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
-- База данных: `kol`
--

-- --------------------------------------------------------

--
-- Структура таблицы `calories`
--

CREATE TABLE `calories` (
  `Id` int(11) NOT NULL,
  `GroupsId` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Calorie` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `calories`
--

INSERT INTO `calories` (`Id`, `GroupsId`, `Name`, `Calorie`) VALUES
(1, 1, 'Мука пшеничная высшего сорта', 354),
(2, 1, 'Мука пшеничная обойная', 343),
(3, 3, 'Баранина вирная', 316),
(4, 3, 'Говядина 1 категории', 187),
(5, 3, 'Говядина жирная', 263),
(6, 4, 'Кальмар', 75),
(7, 4, 'Икра паюсная', 236),
(8, 2, 'Гречка', 171),
(9, 4, '2', 300);

-- --------------------------------------------------------

--
-- Структура таблицы `productgroup`
--

CREATE TABLE `productgroup` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `productgroup`
--

INSERT INTO `productgroup` (`Id`, `Name`) VALUES
(1, 'Мучное'),
(2, 'Крупы'),
(3, 'Мясное'),
(4, 'Морепродукты');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `calories`
--
ALTER TABLE `calories`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `productgroup`
--
ALTER TABLE `productgroup`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `calories`
--
ALTER TABLE `calories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `productgroup`
--
ALTER TABLE `productgroup`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
