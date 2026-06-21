-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 21, 2026 at 10:18 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `labpulse_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `TransactionID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `EquipmentID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `IssueDate` date NOT NULL,
  `ActualReturnDate` date NOT NULL,
  `Status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`TransactionID`, `UserID`, `EquipmentID`, `Quantity`, `IssueDate`, `ActualReturnDate`, `Status`) VALUES
(67, 535377, 7, 5, '2026-06-21', '2026-07-06', 'Returned'),
(456, 1, 3, 1, '2026-06-03', '2026-06-26', 'Returned'),
(12009, 1, 4, 1, '2026-06-20', '2026-07-04', 'Pending'),
(61832, 1, 6, 5, '2026-06-24', '2026-07-08', 'Pending'),
(86479, 1, 1, 1, '2026-06-21', '2026-07-05', 'Pending');

--
-- Triggers `transaction`
--
DELIMITER $$
CREATE TRIGGER `after_transaction_status_approved` AFTER UPDATE ON `transaction` FOR EACH ROW BEGIN
    -- Check if the status is changing from 'Pending' to 'Approved'
    IF OLD.Status = 'Pending' AND NEW.Status = 'Approved' THEN
        
        -- 1. Deduct the transaction quantity from the equipment table
        UPDATE Equipment
        SET `Remaining Quantity` = `Remaining Quantity` - NEW.Quantity
        WHERE EquipmentID = NEW.EquipmentID;
        
        -- 2. Optional: Automatically flag the equipment as Out of Stock if quantity hits 0
        UPDATE Equipment
        SET Status = 'Out of Stock'
        WHERE EquipmentID = NEW.EquipmentID AND `Remaining Quantity` <= 0;
        
    END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`TransactionID`),
  ADD KEY `EquipmentID` (`EquipmentID`),
  ADD KEY `fk_user` (`UserID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `fk_equipment` FOREIGN KEY (`EquipmentID`) REFERENCES `equipment` (`EquipmentID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_user` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
