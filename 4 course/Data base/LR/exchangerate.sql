-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 05 2019 г., 13:06
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
-- База данных: `exchangerate`
--

-- --------------------------------------------------------

--
-- Структура таблицы `city`
--

CREATE TABLE `city` (
  `cityId` int(11) NOT NULL,
  `cityName` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `city`
--

INSERT INTO `city` (`cityId`, `cityName`) VALUES
(1, 'Минск'),
(2, 'Гродно'),
(3, 'Витебск');

-- --------------------------------------------------------

--
-- Структура таблицы `exchangeoffice`
--

CREATE TABLE `exchangeoffice` (
  `exchangeOfficeId` int(11) NOT NULL,
  `exchangeOfficeCityId` int(11) NOT NULL,
  `exchangeOfficeExchangeRate` varchar(255) NOT NULL,
  `exchangeOfficeBuy` int(11) NOT NULL,
  `exchangeOfficeSale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `exchangeoffice`
--

INSERT INTO `exchangeoffice` (`exchangeOfficeId`, `exchangeOfficeCityId`, `exchangeOfficeExchangeRate`, `exchangeOfficeBuy`, `exchangeOfficeSale`) VALUES
(2, 1, 'БПС-Сбербанк', 5020, 5080),
(3, 1, 'БепарусБанк', 8030, 8130),
(4, 1, 'Альфа-Банк', 8010, 8170),
(5, 2, 'БелИнвестБанк', 8000, 8120),
(6, 2, 'БелАгроПромБанк', 8000, 8150),
(7, 3, 'БПС-Сбербанк', 8020, 8080),
(8, 3, 'Альфа-Банк', 8010, 8280),
(9, 2, 'БПС-Сбербанк', 3020, 3080);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `city`
--
ALTER TABLE `city`
  ADD PRIMARY KEY (`cityId`);

--
-- Индексы таблицы `exchangeoffice`
--
ALTER TABLE `exchangeoffice`
  ADD PRIMARY KEY (`exchangeOfficeId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `city`
--
ALTER TABLE `city`
  MODIFY `cityId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `exchangeoffice`
--
ALTER TABLE `exchangeoffice`
  MODIFY `exchangeOfficeId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
