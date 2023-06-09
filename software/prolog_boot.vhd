--
-- Program memory ROM implemented using a case statement.
-- Its content was generated by the microCore cross compiler.
-- It will be statically synthesized into the design as cold bootrom.

LIBRARY IEEE;
USE     IEEE.STD_LOGIC_1164.ALL;
USE     IEEE.NUMERIC_STD.ALL;
USE     work.architecture_pkg.ALL;

ENTITY boot_rom IS PORT (
   addr  : IN   boot_addr_bus;
   data  : OUT  inst_bus
); END boot_rom;

ARCHITECTURE sim_model OF boot_rom IS

SUBTYPE rom_address IS NATURAL RANGE 0 TO 2**boot_addr_width-1;

FUNCTION program(addr : rom_address) RETURN UNSIGNED IS
BEGIN
   CASE addr IS
