-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 10 2018 г., 17:55
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
-- База данных: `Gostinica`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL,
  `telephone` int(11) NOT NULL,
  `pochta` varchar(255) NOT NULL,
  `passport` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`id`, `familiy`, `imy`, `otchestvo`, `telephone`, `pochta`, `passport`) VALUES
(1, 'Стрижак', 'Данил', 'Евгеньевич', 2222222, '2222222@gmail.com', '4504904530'),
(2, 'Веренич', 'Андрей', 'Бориславович', 1234567, '1234567@gmail.com', 'КН8043201');

-- --------------------------------------------------------

--
-- Структура таблицы `Nomera`
--

CREATE TABLE `Nomera` (
  `id` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_uslugi` int(11) NOT NULL,
  `nomer` int(11) NOT NULL,
  `klas` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Nomera`
--

INSERT INTO `Nomera` (`id`, `id_client`, `id_uslugi`, `nomer`, `klas`, `status`) VALUES
(1, 1, 1, 13, 'Обычный', '1'),
(2, 1, 1, 7, 'Люкс', '3');

-- --------------------------------------------------------

--
-- Структура таблицы `Sotrudniki`
--

CREATE TABLE `Sotrudniki` (
  `id` int(11) NOT NULL,
  `doljnost` varchar(255) NOT NULL,
  `zp` decimal(10,0) NOT NULL,
  `stazh` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Sotrudniki`
--

INSERT INTO `Sotrudniki` (`id`, `doljnost`, `zp`, `stazh`) VALUES
(1, 'Уборщица', '350', 15),
(2, 'Администратор', '1400', 7);

-- --------------------------------------------------------

--
-- Структура таблицы `Uslugi`
--

CREATE TABLE `Uslugi` (
  `id` int(11) NOT NULL,
  `opisanie` varchar(255) NOT NULL,
  `stoimost` int(11) NOT NULL,
  `dlitelnost` int(11) NOT NULL,
  `dop_uslugi` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Uslugi`
--

INSERT INTO `Uslugi` (`id`, `opisanie`, `stoimost`, `dlitelnost`, `dop_uslugi`) VALUES
(1, '3-разовая уборка', 12, 3, '-'),
(2, 'Шведский стол', 7, 1, '-');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Nomera`
--
ALTER TABLE `Nomera`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Sotrudniki`
--
ALTER TABLE `Sotrudniki`
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Nomera`
--
ALTER TABLE `Nomera`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Sotrudniki`
--
ALTER TABLE `Sotrudniki`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Uslugi`
--
ALTER TABLE `Uslugi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
