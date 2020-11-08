-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 05 2018 г., 08:00
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
-- База данных: `MyCompanyPractica`
--
CREATE DATABASE IF NOT EXISTS `MyCompanyPractica` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `MyCompanyPractica`;

-- --------------------------------------------------------

--
-- Структура таблицы `TypeOfWork`
--

CREATE TABLE `TypeOfWork` (
  `ID_TypeOfWork` int(11) NOT NULL,
  `Code_TypeOfWork` int(11) NOT NULL,
  `Description_TypeOfWork` text NOT NULL,
  `Payment_TypeOfWork` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `TypeOfWork`
--

INSERT INTO `TypeOfWork` (`ID_TypeOfWork`, `Code_TypeOfWork`, `Description_TypeOfWork`, `Payment_TypeOfWork`) VALUES
(1, 14, 'Ликвидация последствий стихийного бедствия.', 46),
(2, 11, 'В  связи  с  болезнью сменщика требуется сверхурочно отработать.', 30);

-- --------------------------------------------------------

--
-- Структура таблицы `Workers`
--

CREATE TABLE `Workers` (
  `ID_Workers` int(11) NOT NULL,
  `Code_Workers` int(11) NOT NULL,
  `LastName_Wrokers` varchar(255) NOT NULL,
  `FirstName_Workers` varchar(255) NOT NULL,
  `Patronymic_Workers` varchar(255) NOT NULL,
  `Salary_Workers` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Workers`
--

INSERT INTO `Workers` (`ID_Workers`, `Code_Workers`, `LastName_Wrokers`, `FirstName_Workers`, `Patronymic_Workers`, `Salary_Workers`) VALUES
(1, 112, 'Куценко', 'Владислав', 'Егорович', 300),
(2, 791, 'Жук', 'Артём', 'Николаевич', 360),
(3, 446, 'Бендык', 'Константин', 'Генадьевич', 280);

-- --------------------------------------------------------

--
-- Структура таблицы `Works`
--

CREATE TABLE `Works` (
  `ID_Works` int(11) NOT NULL,
  `Code_Workers` int(11) NOT NULL,
  `Code_TypeOfWork` int(11) NOT NULL,
  `StartDate_Works` date NOT NULL,
  `EndDate_Works` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Works`
--

INSERT INTO `Works` (`ID_Works`, `Code_Workers`, `Code_TypeOfWork`, `StartDate_Works`, `EndDate_Works`) VALUES
(1, 446, 14, '2018-02-05', '2018-02-08'),
(2, 791, 11, '2018-02-04', '2018-02-05'),
(6, 112, 2, '2018-02-01', '2018-02-06'),
(9, 791, 14, '2018-01-11', '2018-01-14');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `TypeOfWork`
--
ALTER TABLE `TypeOfWork`
  ADD PRIMARY KEY (`ID_TypeOfWork`);

--
-- Индексы таблицы `Workers`
--
ALTER TABLE `Workers`
  ADD PRIMARY KEY (`ID_Workers`);

--
-- Индексы таблицы `Works`
--
ALTER TABLE `Works`
  ADD PRIMARY KEY (`ID_Works`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `TypeOfWork`
--
ALTER TABLE `TypeOfWork`
  MODIFY `ID_TypeOfWork` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Workers`
--
ALTER TABLE `Workers`
  MODIFY `ID_Workers` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `Works`
--
ALTER TABLE `Works`
  MODIFY `ID_Works` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
