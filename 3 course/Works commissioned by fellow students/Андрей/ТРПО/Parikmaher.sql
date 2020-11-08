-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 08 2018 г., 22:29
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
-- База данных: `Parikmaher`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`id`, `familiy`, `imy`, `otchestvo`) VALUES
(1, 'Скорябкин', 'Артем', 'Казахович'),
(2, 'Кучинский', 'Владислав', 'Хахолович');

-- --------------------------------------------------------

--
-- Структура таблицы `Master`
--

CREATE TABLE `Master` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL,
  `stazh` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Master`
--

INSERT INTO `Master` (`id`, `familiy`, `imy`, `otchestvo`, `stazh`) VALUES
(1, 'Гусь', 'Эрнест', 'Васильевич', 11),
(2, 'Карточник', 'Семен', 'Иудавич', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `Svyz`
--

CREATE TABLE `Svyz` (
  `id` int(11) NOT NULL,
  `id_zapis` int(11) NOT NULL,
  `id_usluga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Svyz`
--

INSERT INTO `Svyz` (`id`, `id_zapis`, `id_usluga`) VALUES
(1, 2, 2),
(2, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Usluga`
--

CREATE TABLE `Usluga` (
  `id` int(11) NOT NULL,
  `nazvanie` varchar(255) NOT NULL,
  `stoimost` float(10,2) NOT NULL,
  `opisanie` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Usluga`
--

INSERT INTO `Usluga` (`id`, `nazvanie`, `stoimost`, `opisanie`) VALUES
(2, 'Мытье головы', 1.50, 'Приятные руки массирующие голову с качественным шампунем'),
(5, '1', 1.00, '1');

-- --------------------------------------------------------

--
-- Структура таблицы `Zapis`
--

CREATE TABLE `Zapis` (
  `id` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_master` int(11) NOT NULL,
  `id_svyz` int(11) NOT NULL,
  `data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Zapis`
--

INSERT INTO `Zapis` (`id`, `id_client`, `id_master`, `id_svyz`, `data`) VALUES
(1, 1, 2, 1, '2018-05-10'),
(2, 2, 1, 2, '2018-05-06');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Master`
--
ALTER TABLE `Master`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Svyz`
--
ALTER TABLE `Svyz`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Usluga`
--
ALTER TABLE `Usluga`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Zapis`
--
ALTER TABLE `Zapis`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Client`
--
ALTER TABLE `Client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Master`
--
ALTER TABLE `Master`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Svyz`
--
ALTER TABLE `Svyz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Usluga`
--
ALTER TABLE `Usluga`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Zapis`
--
ALTER TABLE `Zapis`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
