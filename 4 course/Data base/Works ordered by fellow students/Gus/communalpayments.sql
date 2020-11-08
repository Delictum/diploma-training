-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Окт 27 2018 г., 00:24
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
-- База данных: `communalpayments`
--

-- --------------------------------------------------------

--
-- Структура таблицы `monthcommunalpayments`
--

CREATE TABLE `monthcommunalpayments` (
  `id` int(11) NOT NULL,
  `datePayments` date NOT NULL,
  `namePayments` int(11) NOT NULL,
  `numberPayments` int(11) NOT NULL,
  `fullName` varchar(255) NOT NULL,
  `adress` varchar(255) NOT NULL,
  `sum` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `monthcommunalpayments`
--

INSERT INTO `monthcommunalpayments` (`id`, `datePayments`, `namePayments`, `numberPayments`, `fullName`, `adress`, `sum`) VALUES
(1, '2018-10-01', 1, 4667587, 'Петрович Василий Евгеньевич', 'Гродно, пр-т Янки Купалы, д. 10, кв. 08', '153'),
(2, '2018-10-23', 2, 14234, 'Василек Андрей Игнатьевич', 'Гродно, пр-т Клецкова, д. 87, кв. 109', '123'),
(3, '2018-10-28', 3, 532154, 'Слоновский Петр Михайлович', 'Минск, ул. Тимерязева, д. 101, кв. 231', '147'),
(4, '2018-10-01', 2, 521311, 'Алеська Ирина Марьяновна', 'Могилев, ул. Совецкая, д. 20, кв. 18', '34'),
(5, '2018-10-02', 1, 546788, 'Савицкий Антон Честович', 'Минск, ул. Высоцкого, д. 3, кв. 02', '73');

-- --------------------------------------------------------

--
-- Структура таблицы `namepayments`
--

CREATE TABLE `namepayments` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `namepayments`
--

INSERT INTO `namepayments` (`id`, `name`) VALUES
(1, 'Газоснабжение'),
(2, 'Квартплощадь'),
(3, 'Водоснабжение ');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `monthcommunalpayments`
--
ALTER TABLE `monthcommunalpayments`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `namepayments`
--
ALTER TABLE `namepayments`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `monthcommunalpayments`
--
ALTER TABLE `monthcommunalpayments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `namepayments`
--
ALTER TABLE `namepayments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
