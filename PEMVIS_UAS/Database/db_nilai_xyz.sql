-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 05, 2026 at 12:37 PM
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
('2409106016', 'Azira Faradina', 'P', 'Samarinda', '2006-08-24', 'Loa Bakung, Jalan Jakarta', '08115424806', 'ziruy@gmail.com', '2024'),
('2409106017', 'Ajiva Alank Setiandra', 'L', 'Sanga Sanga', '2006-05-07', 'Sempaja', '08123456789', 'andra@gmail.com', '2025');

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
('BDA20261', 'Basis Data - Kelas A26', 3),
('BDA20262', 'Basis Data - Kelas B26', 3),
('WT20251', 'Wirausaha Teknologi - Kelas A25', 2);

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
  `efektif` decimal(5,2) DEFAULT NULL,
  `nilai` char(2) DEFAULT NULL CHECK (`nilai` in ('A','AB','B','BC','C','D','E')),
  `semester` char(5) NOT NULL,
  `tglInput` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

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
  MODIFY `idLog` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `nilai`
--
ALTER TABLE `nilai`
  MODIFY `idNilai` int(11) NOT NULL AUTO_INCREMENT;

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
