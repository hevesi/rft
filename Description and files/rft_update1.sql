-- Add new column in admin table
ALTER TABLE `rft_admin` 
ADD COLUMN `rank` INT(4) NOT NULL DEFAULT 2 AFTER `active`;

-- Update existing users' rank
UPDATE `rft_admin` SET rank = 1;

-- Add rank table
CREATE TABLE `rft_rank` (
  `id` INT NOT NULL,
  `rank_name` VARCHAR(250) NOT NULL,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  UNIQUE INDEX `rank_name_UNIQUE` (`rank_name` ASC));
  
 -- Insert ranks
 INSERT INTO `rft_rank` (`id`, `rank_name`) VALUES ('1', 'Administrator');
 INSERT INTO `rft_rank` (`id`, `rank_name`) VALUES ('2', 'User');