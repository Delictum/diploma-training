-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 07 2018 г., 23:53
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
-- База данных: `KOL`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `vid` varchar(255) NOT NULL,
  `adress` varchar(255) NOT NULL,
  `telphone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`id`, `name`, `vid`, `adress`, `telphone`) VALUES
(1, 'Арга', 'Сервисное обслуживание', 'Минск, пр-т Скарины 40-2', 80688090),
(2, 'Вилия', 'Производство шин', 'Минск, ул. Слабоды 14-11', 80643032),
(4, '1', '2', '3', 4);

-- --------------------------------------------------------

--
-- Структура таблицы `Sdelki`
--

CREATE TABLE `Sdelki` (
  `id` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_svyz` int(11) NOT NULL,
  `sum` int(11) NOT NULL,
  `komis` int(11) NOT NULL,
  `opis` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Sdelki`
--

INSERT INTO `Sdelki` (`id`, `id_client`, `id_svyz`, `sum`, `komis`, `opis`) VALUES
(1, 2, 1, 500, 30, 'Обслуживание офиса'),
(2, 1, 2, 1200, 90, 'Снабжение шинами'),
(9, 1, 2, 1, 1, '1'),
(10, 1, 1, 1, 2, '3'),
(11, 4, 2, 1, 2, '3');

-- --------------------------------------------------------

--
-- Структура таблицы `Svyz`
--

CREATE TABLE `Svyz` (
  `id` int(11) NOT NULL,
  `id_sdelki` int(11) NOT NULL,
  `id_uslugi` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Svyz`
--

INSERT INTO `Svyz` (`id`, `id_sdelki`, `id_uslugi`) VALUES
(1, 1, 2),
(2, 1, 2),
(3, 1, 1),
(4, 1, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `Uslugi`
--

CREATE TABLE `Uslugi` (
  `id` int(11) NOT NULL,
  `id_svyz` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `opis` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Uslugi`
--

INSERT INTO `Uslugi` (`id`, `id_svyz`, `name`, `opis`) VALUES
(1, 1, 'Обеспечивание офиса', 'Лучшее обслуживание, приветливые работники'),
(2, 2, 'Обеспечивание шинами', 'Самые качественные шины'),
(3, 1, '1', '1'),
(4, 2, '2', '2'),
(5, 2, '2', '3');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Sdelki`
--
ALTER TABLE `Sdelki`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Svyz`
--
ALTER TABLE `Svyz`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Uslugi`
--
ALTER TABLE `Uslugi`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Client`
--
ALTER TABLE `Client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Sdelki`
--
ALTER TABLE `Sdelki`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `Svyz`
--
ALTER TABLE `Svyz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Uslugi`
--
ALTER TABLE `Uslugi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
