-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 04, 2016 at 01:10 PM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 7.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `perpus_csharp`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `db_buku`
--

CREATE TABLE `db_buku` (
  `id` int(11) NOT NULL,
  `judul` varchar(255) NOT NULL,
  `stok` varchar(10) NOT NULL,
  `currentStock` int(11) NOT NULL DEFAULT '0',
  `posisi` varchar(255) NOT NULL,
  `deskripsi` varchar(255) NOT NULL,
  `kategori` varchar(255) NOT NULL,
  `published` date NOT NULL,
  `img` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_buku`
--

INSERT INTO `db_buku` (`id`, `judul`, `stok`, `currentStock`, `posisi`, `deskripsi`, `kategori`, `published`, `img`) VALUES
(1, 'Shigatsu Wa Kimi No Uso', '2', 2, 'Rak 3 - Baris 2', 'Sad Story', 'komik', '2016-04-01', ''),
(2, 'Konosuba', '1', 1, 'Rak 3 - Baris 1', 'Explosion !!', 'komik', '2016-06-02', '');

-- --------------------------------------------------------

--
-- Table structure for table `db_pinjam`
--

CREATE TABLE `db_pinjam` (
  `id` int(11) NOT NULL,
  `idbuku` int(11) NOT NULL,
  `iduser` int(11) NOT NULL,
  `waktu_pinjam` datetime NOT NULL,
  `waktu_kembali` datetime DEFAULT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_pinjam`
--

INSERT INTO `db_pinjam` (`id`, `idbuku`, `iduser`, `waktu_pinjam`, `waktu_kembali`, `status`) VALUES
(1, 2, 14, '2016-06-04 00:00:00', NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `pass` varchar(255) DEFAULT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `ttl` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `pass`, `nama`, `alamat`, `ttl`) VALUES
(4, 'zaid', '827CCB0EEA8A706C4C34A16891F84E7B', 'Muhammad Zaid', 'Bandung', '12345'),
(5, 'zaid555', '827CCB0EEA8A706C4C34A16891F84E7B', 'Muhammad Zaid', 'Bandung, Indonesia', '12345'),
(7, 'zaid123', '827CCB0EEA8A706C4C34A16891F84E7B', 'Muhammad Zaid', 'Bandung, Indonesia', '12345'),
(8, 'zaid143', '827CCB0EEA8A706C4C34A16891F84E7B', 'Muhammad Zaid', 'Bandung, Jawa Barat', '12345'),
(9, 'andre', '827CCB0EEA8A706C4C34A16891F84E7B', 'Andre Prayoga', 'Bandung', '22222'),
(10, 'Heri', '827CCB0EEA8A706C4C34A16891F84E7B', 'Heri Mukti', 'Bandung', '111222'),
(11, 'zaid', '827CCB0EEA8A706C4C34A16891F84E7B', 'Muhammad Zaid', 'Bandung', '12345'),
(12, 'andre', '827CCB0EEA8A706C4C34A16891F84E7B', 'Andre Prayoga', 'Bandung', '22222'),
(13, 'Heri', '827CCB0EEA8A706C4C34A16891F84E7B', 'Heri Mukti', 'Bandung', '111222'),
(14, 'muzazu', '3FDE6BB0541387E4EBDADF7C2FF31123', 'Muzazu', 'Bandung, Indonesia', 'Bandung, 01 Januari 1990');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `db_buku`
--
ALTER TABLE `db_buku`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `db_pinjam`
--
ALTER TABLE `db_pinjam`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `db_buku`
--
ALTER TABLE `db_buku`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `db_pinjam`
--
ALTER TABLE `db_pinjam`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
