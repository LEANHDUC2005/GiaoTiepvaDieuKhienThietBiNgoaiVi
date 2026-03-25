
_interrupt:

;MyProject.c,21 :: 		void interrupt()
;MyProject.c,23 :: 		if (PIR2.USBIF == 1){
	BTFSS       PIR2+0, 5 
	GOTO        L_interrupt0
;MyProject.c,24 :: 		PIR2.USBIF = 0;
	BCF         PIR2+0, 5 
;MyProject.c,25 :: 		USB_Interrupt_Proc();
	CALL        _USB_Interrupt_Proc+0, 0
;MyProject.c,26 :: 		}
L_interrupt0:
;MyProject.c,28 :: 		if (INTCON.INT0IF == 1)
	BTFSS       INTCON+0, 1 
	GOTO        L_interrupt1
;MyProject.c,30 :: 		INTCON.INT0IF = 0;
	BCF         INTCON+0, 1 
;MyProject.c,31 :: 		count_1++;
	INCF        _count_1+0, 1 
;MyProject.c,32 :: 		writebuff[0] = count_1;
	MOVF        _count_1+0, 0 
	MOVWF       1344 
;MyProject.c,33 :: 		SW_trigger = SW1;
	CLRF        _SW_trigger+0 
;MyProject.c,34 :: 		}
L_interrupt1:
;MyProject.c,36 :: 		if (INTCON3.INT1IF == 1){
	BTFSS       INTCON3+0, 0 
	GOTO        L_interrupt2
;MyProject.c,37 :: 		INTCON3.INT1IF = 0;
	BCF         INTCON3+0, 0 
;MyProject.c,38 :: 		LATE.LATE0 = ~PORTE.RE0;
	BTFSC       PORTE+0, 0 
	GOTO        L__interrupt24
	BSF         LATE+0, 0 
	GOTO        L__interrupt25
L__interrupt24:
	BCF         LATE+0, 0 
L__interrupt25:
;MyProject.c,39 :: 		SW_trigger = SW2;
	MOVLW       1
	MOVWF       _SW_trigger+0 
;MyProject.c,40 :: 		}
L_interrupt2:
;MyProject.c,42 :: 		}
L_end_interrupt:
L__interrupt23:
	RETFIE      1
; end of _interrupt

_main:

;MyProject.c,44 :: 		void main(void)
;MyProject.c,46 :: 		ADCON1 = 0x0F;
	MOVLW       15
	MOVWF       ADCON1+0 
;MyProject.c,47 :: 		CMCON  = 0x07;
	MOVLW       7
	MOVWF       CMCON+0 
;MyProject.c,50 :: 		PORTB = 0x00; LATB = 0x00;
	CLRF        PORTB+0 
	CLRF        LATB+0 
;MyProject.c,51 :: 		TRISB.TRISB0 = 1;
	BSF         TRISB+0, 0 
;MyProject.c,52 :: 		TRISB.TRISB1 = 1;
	BSF         TRISB+0, 1 
;MyProject.c,53 :: 		TRISB.TRISB2 = 1;
	BSF         TRISB+0, 2 
;MyProject.c,54 :: 		INTCON2.RBPU = 0x07;
	BSF         INTCON2+0, 7 
;MyProject.c,57 :: 		PORTE = 0x00; LATE = 0x00;
	CLRF        PORTE+0 
	CLRF        LATE+0 
;MyProject.c,58 :: 		TRISE.TRISE1 = 0;
	BCF         TRISE+0, 1 
;MyProject.c,59 :: 		TRISE.TRISE0 = 0;
	BCF         TRISE+0, 0 
;MyProject.c,62 :: 		HID_Enable(&readbuff,&writebuff);
	MOVLW       _readbuff+0
	MOVWF       FARG_HID_Enable_readbuff+0 
	MOVLW       hi_addr(_readbuff+0)
	MOVWF       FARG_HID_Enable_readbuff+1 
	MOVLW       _writebuff+0
	MOVWF       FARG_HID_Enable_writebuff+0 
	MOVLW       hi_addr(_writebuff+0)
	MOVWF       FARG_HID_Enable_writebuff+1 
	CALL        _HID_Enable+0, 0
;MyProject.c,63 :: 		Delay_ms(100);
	MOVLW       3
	MOVWF       R11, 0
	MOVLW       138
	MOVWF       R12, 0
	MOVLW       85
	MOVWF       R13, 0
L_main3:
	DECFSZ      R13, 1, 1
	BRA         L_main3
	DECFSZ      R12, 1, 1
	BRA         L_main3
	DECFSZ      R11, 1, 1
	BRA         L_main3
	NOP
	NOP
;MyProject.c,66 :: 		INTCON.INT0IF = 0;
	BCF         INTCON+0, 1 
;MyProject.c,67 :: 		INTCON.INT0IE = 1;
	BSF         INTCON+0, 4 
;MyProject.c,68 :: 		INTCON2.INTEDG0 = 1;
	BSF         INTCON2+0, 6 
;MyProject.c,70 :: 		INTCON3.INT1IF = 0;
	BCF         INTCON3+0, 0 
;MyProject.c,71 :: 		INTCON3.INT1IE = 1;
	BSF         INTCON3+0, 3 
;MyProject.c,72 :: 		INTCON2.INTEDG1 = 1;
	BSF         INTCON2+0, 5 
;MyProject.c,75 :: 		PIR2.USBIF = 0;
	BCF         PIR2+0, 5 
;MyProject.c,76 :: 		PIE2.USBIE = 1;
	BSF         PIE2+0, 5 
;MyProject.c,78 :: 		UPUEN_bit = 1;
	BSF         UPUEN_bit+0, BitPos(UPUEN_bit+0) 
;MyProject.c,79 :: 		FSEN_bit = 1;
	BSF         FSEN_bit+0, BitPos(FSEN_bit+0) 
;MyProject.c,81 :: 		INTCON.GIE = 1;
	BSF         INTCON+0, 7 
;MyProject.c,82 :: 		INTCON.PEIE = 1;
	BSF         INTCON+0, 6 
;MyProject.c,84 :: 		while(1)
L_main4:
;MyProject.c,86 :: 		if (HID_Read() != 0)
	CALL        _HID_Read+0, 0
	MOVF        R0, 0 
	XORLW       0
	BTFSC       STATUS+0, 2 
	GOTO        L_main6
;MyProject.c,88 :: 		switch(readbuff[0]){
	GOTO        L_main7
;MyProject.c,89 :: 		case 0:
L_main9:
;MyProject.c,90 :: 		LATE.LATE1 = led_off;
	BCF         LATE+0, 1 
;MyProject.c,91 :: 		writebuff[8] = 'F';
	MOVLW       70
	MOVWF       1352 
;MyProject.c,92 :: 		break;
	GOTO        L_main8
;MyProject.c,94 :: 		case 1:
L_main10:
;MyProject.c,95 :: 		LATE.LATE1 = led_on;
	BSF         LATE+0, 1 
;MyProject.c,96 :: 		writebuff[8] = 'O';
	MOVLW       79
	MOVWF       1352 
;MyProject.c,97 :: 		break;
	GOTO        L_main8
;MyProject.c,99 :: 		case 2:
L_main11:
;MyProject.c,100 :: 		LATE.LATE0 = led_on;
	BSF         LATE+0, 0 
;MyProject.c,101 :: 		if(PORTB.RB2 == 1){
	BTFSS       PORTB+0, 2 
	GOTO        L_main12
;MyProject.c,102 :: 		writebuff[8] = 'f';
	MOVLW       102
	MOVWF       1352 
;MyProject.c,103 :: 		}
	GOTO        L_main13
L_main12:
;MyProject.c,105 :: 		writebuff[8] = 'o';
	MOVLW       111
	MOVWF       1352 
;MyProject.c,106 :: 		}
L_main13:
;MyProject.c,107 :: 		break;
	GOTO        L_main8
;MyProject.c,108 :: 		case 3:
L_main14:
;MyProject.c,109 :: 		LATE.LATE0 = led_off;
	BCF         LATE+0, 0 
;MyProject.c,110 :: 		if(PORTB.RB2 == 1){
	BTFSS       PORTB+0, 2 
	GOTO        L_main15
;MyProject.c,111 :: 		writebuff[8] = 'f';
	MOVLW       102
	MOVWF       1352 
;MyProject.c,112 :: 		}
	GOTO        L_main16
L_main15:
;MyProject.c,114 :: 		writebuff[8] = 'o';
	MOVLW       111
	MOVWF       1352 
;MyProject.c,115 :: 		}
L_main16:
;MyProject.c,116 :: 		break;
	GOTO        L_main8
;MyProject.c,117 :: 		default: break;
L_main17:
	GOTO        L_main8
;MyProject.c,118 :: 		}
L_main7:
	MOVF        1280, 0 
	XORLW       0
	BTFSC       STATUS+0, 2 
	GOTO        L_main9
	MOVF        1280, 0 
	XORLW       1
	BTFSC       STATUS+0, 2 
	GOTO        L_main10
	MOVF        1280, 0 
	XORLW       2
	BTFSC       STATUS+0, 2 
	GOTO        L_main11
	MOVF        1280, 0 
	XORLW       3
	BTFSC       STATUS+0, 2 
	GOTO        L_main14
	GOTO        L_main17
L_main8:
;MyProject.c,119 :: 		HID_Write(&writebuff,out_size);
	MOVLW       _writebuff+0
	MOVWF       FARG_HID_Write_writebuff+0 
	MOVLW       hi_addr(_writebuff+0)
	MOVWF       FARG_HID_Write_writebuff+1 
	MOVLW       64
	MOVWF       FARG_HID_Write_len+0 
	CALL        _HID_Write+0, 0
;MyProject.c,120 :: 		}
L_main6:
;MyProject.c,122 :: 		if (SW_trigger == SW1)
	MOVF        _SW_trigger+0, 0 
	XORLW       0
	BTFSS       STATUS+0, 2 
	GOTO        L_main18
;MyProject.c,124 :: 		HID_Write(&writebuff,out_size);
	MOVLW       _writebuff+0
	MOVWF       FARG_HID_Write_writebuff+0 
	MOVLW       hi_addr(_writebuff+0)
	MOVWF       FARG_HID_Write_writebuff+1 
	MOVLW       64
	MOVWF       FARG_HID_Write_len+0 
	CALL        _HID_Write+0, 0
;MyProject.c,125 :: 		SW_trigger = NONE;
	MOVLW       2
	MOVWF       _SW_trigger+0 
;MyProject.c,126 :: 		}
L_main18:
;MyProject.c,128 :: 		if (SW_trigger == SW2){
	MOVF        _SW_trigger+0, 0 
	XORLW       1
	BTFSS       STATUS+0, 2 
	GOTO        L_main19
;MyProject.c,129 :: 		if(PORTB.RB2 == 1){
	BTFSS       PORTB+0, 2 
	GOTO        L_main20
;MyProject.c,130 :: 		writebuff[8] = 'f';
	MOVLW       102
	MOVWF       1352 
;MyProject.c,131 :: 		}
	GOTO        L_main21
L_main20:
;MyProject.c,133 :: 		writebuff[8] = 'o';
	MOVLW       111
	MOVWF       1352 
;MyProject.c,134 :: 		}
L_main21:
;MyProject.c,135 :: 		SW_trigger = NONE;
	MOVLW       2
	MOVWF       _SW_trigger+0 
;MyProject.c,136 :: 		HID_Write(&writebuff,out_size);
	MOVLW       _writebuff+0
	MOVWF       FARG_HID_Write_writebuff+0 
	MOVLW       hi_addr(_writebuff+0)
	MOVWF       FARG_HID_Write_writebuff+1 
	MOVLW       64
	MOVWF       FARG_HID_Write_len+0 
	CALL        _HID_Write+0, 0
;MyProject.c,137 :: 		}
L_main19:
;MyProject.c,139 :: 		}
	GOTO        L_main4
;MyProject.c,140 :: 		}
L_end_main:
	GOTO        $+0
; end of _main
