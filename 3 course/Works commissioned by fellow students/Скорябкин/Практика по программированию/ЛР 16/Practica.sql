-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 06 2018 г., 10:13
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
-- База данных: `Practica`
--

-- --------------------------------------------------------

--
-- Структура таблицы `MachineTypes`
--

CREATE TABLE `MachineTypes` (
  `ID` int(11) NOT NULL,
  `CodeMachine` int(11) NOT NULL,
  `Country` varchar(255) NOT NULL,
  `Year` int(11) NOT NULL,
  `Mark` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `MachineTypes`
--

INSERT INTO `MachineTypes` (`ID`, `CodeMachine`, `Country`, `Year`, `Mark`) VALUES
(1, 512, 'Россия', 2011, 'FR'),
(2, 478, 'Украина', 2006, 'UL');

-- --------------------------------------------------------

--
-- Структура таблицы `Repair`
--

CREATE TABLE `Repair` (
  `ID` int(11) NOT NULL,
  `CodeMachine` int(11) NOT NULL,
  `CodeRepair` int(11) NOT NULL,
  `DateStart` date NOT NULL,
  `Notes` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Repair`
--

INSERT INTO `Repair` (`ID`, `CodeMachine`, `CodeRepair`, `DateStart`, `Notes`) VALUES
(1, 512, 4, '2018-02-06', 'Шифр An0931.'),
(2, 478, 3, '2018-02-07', 'Комплект запчастей в наличии.'),
(4, 1, 1, '2018-11-11', '1'),
(7, 478, 3, '2018-02-20', '!');

-- --------------------------------------------------------

--
-- Структура таблицы `RepairType`
--

CREATE TABLE `RepairType` (
  `ID` int(11) NOT NULL,
  `CodeRepair` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Duration` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `Notes` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `RepairType`
--

INSERT INTO `RepairType` (`ID`, `CodeRepair`, `Name`, `Duration`, `Price`, `Notes`) VALUES
(1, 4, 'Диагностика', 1, 10, 'Полный осмотр станка с выявлением неисправности.'),
(3, 3, '3', 3, 3, '3');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `MachineTypes`
--
ALTER TABLE `MachineTypes`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `Repair`
--
ALTER TABLE `Repair`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `RepairType`
--
ALTER TABLE `RepairType`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `MachineTypes`
--
ALTER TABLE `MachineTypes`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Repair`
--
ALTER TABLE `Repair`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `RepairType`
--
ALTER TABLE `RepairType`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
