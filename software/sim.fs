\ 
\ Last change: KS 12.07.2023 19:28:53
\
\ microCore load screen for simulation.
\ It produces program.mem for initialization of the program memory during simulation.
\
Only Forth also definitions hex

[IFDEF] unpatch     unpatch    [ENDIF]
[IFDEF] close-port  close-port [ENDIF]
[IFDEF] microcore   microcore  [ENDIF]   Marker microcore

include extensions.fs           \ Some System word (re)definitions for a more sympathetic environment
include ../vhdl/architecture_pkg_sim.vhd
include microcross.fs           \ the cross-compiler

Target new initialized          \ go into target compilation mode and initialize target compiler

6 trap-addr code-origin
          0 data-origin

include constants.fs            \ MicroCore Register addresses and bits
library forth_lib.fs

\ ----------------------------------------------------------------------
\ Booting and TRAPs
\ ----------------------------------------------------------------------

: boot  ( -- )   3 0 DO I drop 2 +LOOP  -5 0 DO I drop -2 +LOOP BEGIN REPEAT ;

#reset TRAP: rst    ( -- )            boot              ;  \ compile branch to boot at reset vector location
#isr   TRAP: isr    ( -- )            di IRET           ;
#psr   TRAP: psr    ( -- )            pause             ;  \ reexecute the previous instruction

end

MEM-file program.mem cr .( sim.fs written to program.mem )
