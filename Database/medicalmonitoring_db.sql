-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 08, 2020 at 06:16 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `medicalmonitoring_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `PatientCode` varchar(20) NOT NULL,
  `Firstname` varchar(100) DEFAULT NULL,
  `Middlename` varchar(100) DEFAULT NULL,
  `Lastname` varchar(100) DEFAULT NULL,
  `BirthDate` datetime DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdatedBy` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`PatientCode`, `Firstname`, `Middlename`, `Lastname`, `BirthDate`, `Address`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
('00000001', 'test', 'test', 'test', '0000-00-00 00:00:00', 'asdasdasd', '2020-11-08 12:43:20', NULL, '2020-11-08 12:43:20', '34980'),
('00000002', 'asd', 'asda', 'asd', '0000-00-00 00:00:00', 'sdasd', '2020-11-08 12:44:01', NULL, '2020-11-08 12:44:01', '34980'),
('00000003', 'a', 'a', 'a', '0000-00-00 00:00:00', 'a', '2020-11-08 12:44:33', NULL, '2020-11-08 12:44:33', '34980'),
('00000004', 'asd', 'asd', 'asd', '0000-00-00 00:00:00', 'd', '2020-11-08 12:50:05', NULL, '2020-11-08 12:50:05', '34980'),
('00000005', 'a', 'a', 'a', '0000-00-00 00:00:00', 'a', '2020-11-08 12:51:00', NULL, '2020-11-08 12:51:00', '34980'),
('00000006', '1', '1', '1', '0000-00-00 00:00:00', '1', '2020-11-08 12:52:41', NULL, '2020-11-08 12:52:41', '34980');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserCode` varchar(10) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `UserRights` int(1) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdatedBy` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserCode`, `Username`, `Password`, `UserRights`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
('34980', '34980', '34980', 1, '2020-11-06 18:17:51', NULL, '2020-11-06 18:17:51', '34980');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`PatientCode`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserCode`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
