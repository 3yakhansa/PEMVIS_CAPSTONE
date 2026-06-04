-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 04, 2026 at 03:39 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_nilai_xyz`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `nimAdmin` char(10) NOT NULL,
  `namaAdmin` varchar(100) NOT NULL,
  `jabatan` varchar(50) DEFAULT NULL,
  `noTelp` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `idLog` int(11) NOT NULL,
  `tanggalJam` datetime NOT NULL DEFAULT current_timestamp(),
  `aktifitas` varchar(255) NOT NULL,
  `nimAdmin` char(10) NOT NULL,
  `ipAddress` varchar(50) DEFAULT NULL,
  `keterangan` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `nim` char(10) NOT NULL,
  `namaMahasiswa` varchar(100) NOT NULL,
  `jenisKelamin` char(1) NOT NULL CHECK (`jenisKelamin` in ('L','P')),
  `tempatLahir` varchar(50) DEFAULT NULL,
  `tanggalLahir` date DEFAULT NULL,
  `alamat` varchar(200) DEFAULT NULL,
  `noTelp` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `angkatan` char(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`nim`, `namaMahasiswa`, `jenisKelamin`, `tempatLahir`, `tanggalLahir`, `alamat`, `noTelp`, `email`, `angkatan`) VALUES
('2409106001', 'Andi Saputra', 'L', 'Samarinda', '2004-01-01', 'Jl. A', '0811111111', 'andi@gmail.com', '2024'),
('2409106002', 'Budi Santoso', 'L', 'Balikpapan', '2004-02-02', 'Jl. B', '0822222222', 'budi@gmail.com', '2024');

-- --------------------------------------------------------

--
-- Table structure for table `matakuliah`
--

CREATE TABLE `matakuliah` (
  `kodeMK` char(10) NOT NULL,
  `namaMK` varchar(100) NOT NULL,
  `sks` tinyint(4) NOT NULL CHECK (`sks` between 1 and 6)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `matakuliah`
--

INSERT INTO `matakuliah` (`kodeMK`, `namaMK`, `sks`) VALUES
('MK001', 'Pemrograman Visual', 3),
('MK002', 'Basis Data', 3),
('MK003', 'Pemrograman Web', 3);

-- --------------------------------------------------------

--
-- Table structure for table `nilai`
--

CREATE TABLE `nilai` (
  `idNilai` int(11) NOT NULL,
  `nim` char(10) NOT NULL,
  `kodeMK` char(10) NOT NULL,
  `tugas` decimal(5,2) DEFAULT NULL CHECK (`tugas` between 0 and 100),
  `praktikum` decimal(5,2) DEFAULT NULL CHECK (`praktikum` between 0 and 100),
  `uts` decimal(5,2) DEFAULT NULL CHECK (`uts` between 0 and 100),
  `uas` decimal(5,2) DEFAULT NULL CHECK (`uas` between 0 and 100),
  `afektif` decimal(5,2) DEFAULT 0.00,
  `nilaiAkhir` decimal(5,2) DEFAULT NULL,
  `predikat` char(2) DEFAULT NULL,
  `semester` char(5) NOT NULL,
  `tglInput` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `nilai`
--

INSERT INTO `nilai` (`idNilai`, `nim`, `kodeMK`, `tugas`, `praktikum`, `uts`, `uas`, `afektif`, `nilaiAkhir`, `predikat`, `semester`, `tglInput`) VALUES
(1, '2409106001', 'MK002', 90.00, 40.00, 80.00, 50.00, 80.00, 67.00, 'C', '2', '2026-06-03 14:52:47'),
(2, '2409106002', 'MK001', 100.00, 80.00, 100.00, 80.00, 90.00, 91.00, 'A', '4', '2026-06-03 14:56:00'),
(4, '2409106001', 'MK003', 70.00, 90.00, 70.00, 70.00, 80.00, 74.00, 'B', '2', '2026-06-03 16:09:16'),
(5, '2409106002', 'MK002', 100.00, 90.00, 70.00, 70.00, 48.90, 76.80, 'B', '4', '2026-06-03 16:21:00'),
(6, '2409106002', 'MK003', 70.00, 90.00, 85.00, 80.00, 90.00, 81.75, 'A', '8', '2026-06-03 16:45:27'),
(7, '2409106002', 'MK001', 86.00, 93.00, 85.00, 70.00, 95.00, 82.90, 'A', '7', '2026-06-03 16:59:28');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `idUser` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `lvl` tinyint(4) NOT NULL CHECK (`lvl` in (1,2)),
  `nimRef` char(10) DEFAULT NULL,
  `isActive` tinyint(1) NOT NULL DEFAULT 1,
  `lastLogin` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`nimAdmin`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`idLog`),
  ADD KEY `nimAdmin` (`nimAdmin`);

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`nim`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `matakuliah`
--
ALTER TABLE `matakuliah`
  ADD PRIMARY KEY (`kodeMK`);

--
-- Indexes for table `nilai`
--
ALTER TABLE `nilai`
  ADD PRIMARY KEY (`idNilai`),
  ADD UNIQUE KEY `uq_nilai` (`nim`,`kodeMK`,`semester`),
  ADD KEY `kodeMK` (`kodeMK`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`idUser`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `idLog` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nilai`
--
ALTER TABLE `nilai`
  MODIFY `idNilai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `log_ibfk_1` FOREIGN KEY (`nimAdmin`) REFERENCES `admin` (`nimAdmin`) ON UPDATE CASCADE;

--
-- Constraints for table `nilai`
--
ALTER TABLE `nilai`
  ADD CONSTRAINT `nilai_ibfk_1` FOREIGN KEY (`nim`) REFERENCES `mahasiswa` (`nim`) ON UPDATE CASCADE,
  ADD CONSTRAINT `nilai_ibfk_2` FOREIGN KEY (`kodeMK`) REFERENCES `matakuliah` (`kodeMK`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
