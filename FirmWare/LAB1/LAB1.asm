
_interrupt:

;LAB1.c,29 :: 		void interrupt(){
;LAB1.c,30 :: 		if(INTCON3.INT1IF){
	BTFSS       INTCON3+0, 0 
	GOTO        L_interrupt0
;LAB1.c,31 :: 		INTCON3.INT1IF = 0;
	BCF         INTCON3+0, 0 
;LAB1.c,32 :: 		LATE.LATE0 = ~LATE.LATE0;
	BTG         LATE+0, 0 
;LAB1.c,33 :: 		if(PORTB.RB2 == 1)
	BTFSS       PORTB+0, 2 
	GOTO        L_interrupt1
;LAB1.c,34 :: 		LED_State = OFF;
	MOVLW       1
	MOVWF       _LED_State+0 
	GOTO        L_interrupt2
L_interrupt1:
;LAB1.c,36 :: 		LED_State = ON;
	CLRF        _LED_State+0 
L_interrupt2:
;LAB1.c,37 :: 		}
	GOTO        L_interrupt3
L_interrupt0:
;LAB1.c,39 :: 		else if(INTCON.INT0IF){
	BTFSS       INTCON+0, 1 
	GOTO        L_interrupt4
;LAB1.c,40 :: 		INTCON.INT0IF = 0;
	BCF         INTCON+0, 1 
;LAB1.c,41 :: 		if(countSW > 255) countSW = 0;
	MOVLW       0
	MOVWF       R0 
	MOVF        _countSW+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__interrupt44
	MOVF        _countSW+0, 0 
	SUBLW       255
L__interrupt44:
	BTFSC       STATUS+0, 0 
	GOTO        L_interrupt5
	CLRF        _countSW+0 
	CLRF        _countSW+1 
L_interrupt5:
;LAB1.c,42 :: 		countSW++;
	MOVLW       1
	ADDWF       _countSW+0, 0 
	MOVWF       R0 
	MOVLW       0
	ADDWFC      _countSW+1, 0 
	MOVWF       R1 
	MOVF        R0, 0 
	MOVWF       _countSW+0 
	MOVF        R1, 0 
	MOVWF       _countSW+1 
;LAB1.c,43 :: 		SW_RB0_Pressed = 1;
	MOVLW       1
	MOVWF       _SW_RB0_Pressed+0 
;LAB1.c,44 :: 		}
	GOTO        L_interrupt6
L_interrupt4:
;LAB1.c,46 :: 		else if(INTCON3.INT2IF){
	BTFSS       INTCON3+0, 1 
	GOTO        L_interrupt7
;LAB1.c,47 :: 		INTCON3.INT2IF = 0;
	BCF         INTCON3+0, 1 
;LAB1.c,48 :: 		}
	GOTO        L_interrupt8
L_interrupt7:
;LAB1.c,50 :: 		else if(PIR1.RCIF){
	BTFSS       PIR1+0, 5 
	GOTO        L_interrupt9
;LAB1.c,51 :: 		char c = UART_Read();
	CALL        _UART_Read+0, 0
	MOVF        R0, 0 
	MOVWF       interrupt_c_L1+0 
;LAB1.c,52 :: 		switch(State){
	GOTO        L_interrupt10
;LAB1.c,53 :: 		case IDLE:
L_interrupt12:
;LAB1.c,54 :: 		if(c == '@'){
	MOVF        interrupt_c_L1+0, 0 
	XORLW       64
	BTFSS       STATUS+0, 2 
	GOTO        L_interrupt13
;LAB1.c,55 :: 		receiveIndex = 0;
	CLRF        _receiveIndex+0 
;LAB1.c,56 :: 		receiveData[receiveIndex++] = c;
	MOVLW       _receiveData+0
	MOVWF       FSR1L+0 
	MOVLW       hi_addr(_receiveData+0)
	MOVWF       FSR1L+1 
	MOVF        _receiveIndex+0, 0 
	ADDWF       FSR1L+0, 1 
	BTFSC       STATUS+0, 0 
	INCF        FSR1L+1, 1 
	MOVF        interrupt_c_L1+0, 0 
	MOVWF       POSTINC1+0 
	MOVF        _receiveIndex+0, 0 
	ADDLW       1
	MOVWF       R0 
	MOVF        R0, 0 
	MOVWF       _receiveIndex+0 
;LAB1.c,57 :: 		State = RECEIVING;
	MOVLW       1
	MOVWF       _State+0 
;LAB1.c,58 :: 		}
L_interrupt13:
;LAB1.c,59 :: 		break;
	GOTO        L_interrupt11
;LAB1.c,60 :: 		case RECEIVING:
L_interrupt14:
;LAB1.c,61 :: 		if(receiveIndex < RX_MAX){
	MOVLW       12
	SUBWF       _receiveIndex+0, 0 
	BTFSC       STATUS+0, 0 
	GOTO        L_interrupt15
;LAB1.c,62 :: 		receiveData[receiveIndex++] = c;
	MOVLW       _receiveData+0
	MOVWF       FSR1L+0 
	MOVLW       hi_addr(_receiveData+0)
	MOVWF       FSR1L+1 
	MOVF        _receiveIndex+0, 0 
	ADDWF       FSR1L+0, 1 
	BTFSC       STATUS+0, 0 
	INCF        FSR1L+1, 1 
	MOVF        interrupt_c_L1+0, 0 
	MOVWF       POSTINC1+0 
	MOVF        _receiveIndex+0, 0 
	ADDLW       1
	MOVWF       R0 
	MOVF        R0, 0 
	MOVWF       _receiveIndex+0 
;LAB1.c,63 :: 		}
	GOTO        L_interrupt16
L_interrupt15:
;LAB1.c,65 :: 		receiveIndex = 0;
	CLRF        _receiveIndex+0 
;LAB1.c,66 :: 		State = IDLE;
	CLRF        _State+0 
;LAB1.c,67 :: 		break;
	GOTO        L_interrupt11
;LAB1.c,68 :: 		}
L_interrupt16:
;LAB1.c,69 :: 		if(c == '&'){
	MOVF        interrupt_c_L1+0, 0 
	XORLW       38
	BTFSS       STATUS+0, 2 
	GOTO        L_interrupt17
;LAB1.c,70 :: 		receiveData[receiveIndex] = '\0';
	MOVLW       _receiveData+0
	MOVWF       FSR1L+0 
	MOVLW       hi_addr(_receiveData+0)
	MOVWF       FSR1L+1 
	MOVF        _receiveIndex+0, 0 
	ADDWF       FSR1L+0, 1 
	BTFSC       STATUS+0, 0 
	INCF        FSR1L+1, 1 
	CLRF        POSTINC1+0 
;LAB1.c,71 :: 		frameComplete = 1;
	MOVLW       1
	MOVWF       _frameComplete+0 
;LAB1.c,72 :: 		State = IDLE;
	CLRF        _State+0 
;LAB1.c,73 :: 		}
L_interrupt17:
;LAB1.c,74 :: 		break;
	GOTO        L_interrupt11
;LAB1.c,75 :: 		default: break;
L_interrupt18:
	GOTO        L_interrupt11
;LAB1.c,76 :: 		}
L_interrupt10:
	MOVF        _State+0, 0 
	XORLW       0
	BTFSC       STATUS+0, 2 
	GOTO        L_interrupt12
	MOVF        _State+0, 0 
	XORLW       1
	BTFSC       STATUS+0, 2 
	GOTO        L_interrupt14
	GOTO        L_interrupt18
L_interrupt11:
;LAB1.c,77 :: 		}
L_interrupt9:
L_interrupt8:
L_interrupt6:
L_interrupt3:
;LAB1.c,78 :: 		}
L_end_interrupt:
L__interrupt43:
	RETFIE      1
; end of _interrupt

_ioInit:

;LAB1.c,80 :: 		void ioInit(){
;LAB1.c,82 :: 		ADCON1 = 0x0F;
	MOVLW       15
	MOVWF       ADCON1+0 
;LAB1.c,83 :: 		CMCON = 0x07;
	MOVLW       7
	MOVWF       CMCON+0 
;LAB1.c,86 :: 		TRISB.TRISB0 = 1;
	BSF         TRISB+0, 0 
;LAB1.c,87 :: 		TRISB.TRISB1 = 1;
	BSF         TRISB+0, 1 
;LAB1.c,88 :: 		TRISB.TRISB2 = 1;
	BSF         TRISB+0, 2 
;LAB1.c,89 :: 		INTCON2.RBPU = 0x07;
	BSF         INTCON2+0, 7 
;LAB1.c,93 :: 		PORTE.RE0 = 0;
	BCF         PORTE+0, 0 
;LAB1.c,94 :: 		PORTE.RE1 = 0;
	BCF         PORTE+0, 1 
;LAB1.c,95 :: 		TRISE.TRISE0 = 0;
	BCF         TRISE+0, 0 
;LAB1.c,96 :: 		TRISE.TRISE1 = 0;
	BCF         TRISE+0, 1 
;LAB1.c,97 :: 		LATE = 0;
	CLRF        LATE+0 
;LAB1.c,100 :: 		INTCON.INT0IE = 1; // SW0
	BSF         INTCON+0, 4 
;LAB1.c,101 :: 		INTCON.INT0IF = 0;
	BCF         INTCON+0, 1 
;LAB1.c,102 :: 		INTCON2.INTEDG0 = 1;
	BSF         INTCON2+0, 6 
;LAB1.c,104 :: 		INTCON3.INT1IE = 1;  // SW1
	BSF         INTCON3+0, 3 
;LAB1.c,105 :: 		INTCON3.INT1IF = 0;
	BCF         INTCON3+0, 0 
;LAB1.c,106 :: 		INTCON2.INTEDG1 = 1;
	BSF         INTCON2+0, 5 
;LAB1.c,108 :: 		INTCON2.INTEDG2 = 1; // ngat canh len
	BSF         INTCON2+0, 4 
;LAB1.c,109 :: 		INTCON3.INT2IF = 0;  // clear flag
	BCF         INTCON3+0, 1 
;LAB1.c,110 :: 		INTCON3.INT2IE = 1;  // enable INT2
	BSF         INTCON3+0, 4 
;LAB1.c,112 :: 		PIE1.RCIE = 1;
	BSF         PIE1+0, 5 
;LAB1.c,113 :: 		PIE1.TXIE = 0;     // UART
	BCF         PIE1+0, 4 
;LAB1.c,114 :: 		INTCON.PEIE = 1;
	BSF         INTCON+0, 6 
;LAB1.c,115 :: 		INTCON.GIE = 1;
	BSF         INTCON+0, 7 
;LAB1.c,116 :: 		}
L_end_ioInit:
	RETURN      0
; end of _ioInit

_main:

;LAB1.c,118 :: 		void main(){
;LAB1.c,119 :: 		ioInit();
	CALL        _ioInit+0, 0
;LAB1.c,120 :: 		UART1_Init(9600);
	BSF         BAUDCON+0, 3, 0
	MOVLW       2
	MOVWF       SPBRGH+0 
	MOVLW       8
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;LAB1.c,121 :: 		delay_ms(100);
	MOVLW       3
	MOVWF       R11, 0
	MOVLW       138
	MOVWF       R12, 0
	MOVLW       85
	MOVWF       R13, 0
L_main19:
	DECFSZ      R13, 1, 1
	BRA         L_main19
	DECFSZ      R12, 1, 1
	BRA         L_main19
	DECFSZ      R11, 1, 1
	BRA         L_main19
	NOP
	NOP
;LAB1.c,122 :: 		while(1){
L_main20:
;LAB1.c,123 :: 		if(SW_RB0_Pressed){
	MOVF        _SW_RB0_Pressed+0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main22
;LAB1.c,124 :: 		sprintf(transmitData, "@S%d&", countSW);
	MOVLW       _transmitData+0
	MOVWF       FARG_sprintf_wh+0 
	MOVLW       hi_addr(_transmitData+0)
	MOVWF       FARG_sprintf_wh+1 
	MOVLW       ?lstr_1_LAB1+0
	MOVWF       FARG_sprintf_f+0 
	MOVLW       hi_addr(?lstr_1_LAB1+0)
	MOVWF       FARG_sprintf_f+1 
	MOVLW       higher_addr(?lstr_1_LAB1+0)
	MOVWF       FARG_sprintf_f+2 
	MOVF        _countSW+0, 0 
	MOVWF       FARG_sprintf_wh+5 
	MOVF        _countSW+1, 0 
	MOVWF       FARG_sprintf_wh+6 
	CALL        _sprintf+0, 0
;LAB1.c,125 :: 		UART_Write_Text(transmitData);
	MOVLW       _transmitData+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(_transmitData+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,126 :: 		SW_RB0_Pressed = 0;
	CLRF        _SW_RB0_Pressed+0 
;LAB1.c,127 :: 		}
	GOTO        L_main23
L_main22:
;LAB1.c,129 :: 		else if(frameComplete){
	MOVF        _frameComplete+0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main24
;LAB1.c,130 :: 		strcpy(frameLocal, receiveData);
	MOVLW       _frameLocal+0
	MOVWF       FARG_strcpy_to+0 
	MOVLW       hi_addr(_frameLocal+0)
	MOVWF       FARG_strcpy_to+1 
	MOVLW       _receiveData+0
	MOVWF       FARG_strcpy_from+0 
	MOVLW       hi_addr(_receiveData+0)
	MOVWF       FARG_strcpy_from+1 
	CALL        _strcpy+0, 0
;LAB1.c,131 :: 		if(strcmp("@le_on&", frameLocal) == 0){
	MOVLW       ?lstr2_LAB1+0
	MOVWF       FARG_strcmp_s1+0 
	MOVLW       hi_addr(?lstr2_LAB1+0)
	MOVWF       FARG_strcmp_s1+1 
	MOVLW       _frameLocal+0
	MOVWF       FARG_strcmp_s2+0 
	MOVLW       hi_addr(_frameLocal+0)
	MOVWF       FARG_strcmp_s2+1 
	CALL        _strcmp+0, 0
	MOVLW       0
	XORWF       R1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main47
	MOVLW       0
	XORWF       R0, 0 
L__main47:
	BTFSS       STATUS+0, 2 
	GOTO        L_main25
;LAB1.c,132 :: 		LATE.LATE1 = LED_ON;
	BSF         LATE+0, 1 
;LAB1.c,133 :: 		UART_Write_Text("@Lle_on&");
	MOVLW       ?lstr3_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr3_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,134 :: 		}
	GOTO        L_main26
L_main25:
;LAB1.c,135 :: 		else if(strcmp("@le_of&", frameLocal) == 0){
	MOVLW       ?lstr4_LAB1+0
	MOVWF       FARG_strcmp_s1+0 
	MOVLW       hi_addr(?lstr4_LAB1+0)
	MOVWF       FARG_strcmp_s1+1 
	MOVLW       _frameLocal+0
	MOVWF       FARG_strcmp_s2+0 
	MOVLW       hi_addr(_frameLocal+0)
	MOVWF       FARG_strcmp_s2+1 
	CALL        _strcmp+0, 0
	MOVLW       0
	XORWF       R1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main48
	MOVLW       0
	XORWF       R0, 0 
L__main48:
	BTFSS       STATUS+0, 2 
	GOTO        L_main27
;LAB1.c,136 :: 		LATE.LATE1 = LED_OFF;
	BCF         LATE+0, 1 
;LAB1.c,137 :: 		UART_Write_Text("@Lle_of&");
	MOVLW       ?lstr5_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr5_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,138 :: 		}
	GOTO        L_main28
L_main27:
;LAB1.c,139 :: 		else if(strcmp("@le+_on&", frameLocal) == 0){
	MOVLW       ?lstr6_LAB1+0
	MOVWF       FARG_strcmp_s1+0 
	MOVLW       hi_addr(?lstr6_LAB1+0)
	MOVWF       FARG_strcmp_s1+1 
	MOVLW       _frameLocal+0
	MOVWF       FARG_strcmp_s2+0 
	MOVLW       hi_addr(_frameLocal+0)
	MOVWF       FARG_strcmp_s2+1 
	CALL        _strcmp+0, 0
	MOVLW       0
	XORWF       R1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main49
	MOVLW       0
	XORWF       R0, 0 
L__main49:
	BTFSS       STATUS+0, 2 
	GOTO        L_main29
;LAB1.c,140 :: 		LATE.LATE0 = LED_ON;
	BSF         LATE+0, 0 
;LAB1.c,141 :: 		if(PORTB.RB2 == 1){
	BTFSS       PORTB+0, 2 
	GOTO        L_main30
;LAB1.c,142 :: 		UART_Write_Text("@Lle+_of&");
	MOVLW       ?lstr7_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr7_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,143 :: 		}
	GOTO        L_main31
L_main30:
;LAB1.c,145 :: 		UART_Write_Text("@Lle+_on&");
	MOVLW       ?lstr8_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr8_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,146 :: 		}
L_main31:
;LAB1.c,147 :: 		}
	GOTO        L_main32
L_main29:
;LAB1.c,148 :: 		else if(strcmp("@le+_of&", frameLocal) == 0){
	MOVLW       ?lstr9_LAB1+0
	MOVWF       FARG_strcmp_s1+0 
	MOVLW       hi_addr(?lstr9_LAB1+0)
	MOVWF       FARG_strcmp_s1+1 
	MOVLW       _frameLocal+0
	MOVWF       FARG_strcmp_s2+0 
	MOVLW       hi_addr(_frameLocal+0)
	MOVWF       FARG_strcmp_s2+1 
	CALL        _strcmp+0, 0
	MOVLW       0
	XORWF       R1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main50
	MOVLW       0
	XORWF       R0, 0 
L__main50:
	BTFSS       STATUS+0, 2 
	GOTO        L_main33
;LAB1.c,149 :: 		LATE.LATE0 = LED_OFF;
	BCF         LATE+0, 0 
;LAB1.c,150 :: 		if(PORTB.RB2 == 1){
	BTFSS       PORTB+0, 2 
	GOTO        L_main34
;LAB1.c,151 :: 		UART_Write_Text("@Lle+_of&");
	MOVLW       ?lstr10_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr10_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,152 :: 		}
	GOTO        L_main35
L_main34:
;LAB1.c,154 :: 		UART_Write_Text("@Lle+_on&");
	MOVLW       ?lstr11_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr11_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,155 :: 		}
L_main35:
;LAB1.c,156 :: 		}
	GOTO        L_main36
L_main33:
;LAB1.c,158 :: 		UART_Write_Text("@Error&");
	MOVLW       ?lstr12_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr12_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,159 :: 		}
L_main36:
L_main32:
L_main28:
L_main26:
;LAB1.c,160 :: 		frameComplete = 0;
	CLRF        _frameComplete+0 
;LAB1.c,161 :: 		}
L_main24:
L_main23:
;LAB1.c,163 :: 		switch(LED_State){
	GOTO        L_main37
;LAB1.c,164 :: 		case ON:
L_main39:
;LAB1.c,165 :: 		UART_Write_Text("@Lle+_on&");
	MOVLW       ?lstr13_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr13_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,166 :: 		LED_State = NONE;
	MOVLW       2
	MOVWF       _LED_State+0 
;LAB1.c,167 :: 		break;
	GOTO        L_main38
;LAB1.c,169 :: 		case OFF:
L_main40:
;LAB1.c,170 :: 		UART_Write_Text("@Lle+_of&");
	MOVLW       ?lstr14_LAB1+0
	MOVWF       FARG_UART_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr14_LAB1+0)
	MOVWF       FARG_UART_Write_Text_uart_text+1 
	CALL        _UART_Write_Text+0, 0
;LAB1.c,171 :: 		LED_State = NONE;
	MOVLW       2
	MOVWF       _LED_State+0 
;LAB1.c,172 :: 		break;
	GOTO        L_main38
;LAB1.c,174 :: 		case NONE: break;
L_main41:
	GOTO        L_main38
;LAB1.c,175 :: 		}
L_main37:
	MOVF        _LED_State+0, 0 
	XORLW       0
	BTFSC       STATUS+0, 2 
	GOTO        L_main39
	MOVF        _LED_State+0, 0 
	XORLW       1
	BTFSC       STATUS+0, 2 
	GOTO        L_main40
	MOVF        _LED_State+0, 0 
	XORLW       2
	BTFSC       STATUS+0, 2 
	GOTO        L_main41
L_main38:
;LAB1.c,176 :: 		}
	GOTO        L_main20
;LAB1.c,177 :: 		}
L_end_main:
	GOTO        $+0
; end of _main
