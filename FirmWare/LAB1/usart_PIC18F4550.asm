
_UART_Init:

;usart_PIC18F4550.c,24 :: 		void UART_Init(const unsigned long baud_rate)
;usart_PIC18F4550.c,28 :: 		TRISC6_bit = 0; // TX
	BCF         TRISC6_bit+0, BitPos(TRISC6_bit+0) 
;usart_PIC18F4550.c,29 :: 		TRISC7_bit = 1; // RX
	BSF         TRISC7_bit+0, BitPos(TRISC7_bit+0) 
;usart_PIC18F4550.c,31 :: 		temp = ((float)F_CPU / (64 * (float)baud_rate) - 1);
	MOVF        FARG_UART_Init_baud_rate+0, 0 
	MOVWF       R0 
	MOVF        FARG_UART_Init_baud_rate+1, 0 
	MOVWF       R1 
	MOVF        FARG_UART_Init_baud_rate+2, 0 
	MOVWF       R2 
	MOVF        FARG_UART_Init_baud_rate+3, 0 
	MOVWF       R3 
	CALL        _longword2double+0, 0
	MOVLW       0
	MOVWF       R4 
	MOVLW       0
	MOVWF       R5 
	MOVLW       0
	MOVWF       R6 
	MOVLW       133
	MOVWF       R7 
	CALL        _Mul_32x32_FP+0, 0
	MOVF        R0, 0 
	MOVWF       R4 
	MOVF        R1, 0 
	MOVWF       R5 
	MOVF        R2, 0 
	MOVWF       R6 
	MOVF        R3, 0 
	MOVWF       R7 
	MOVLW       128
	MOVWF       R0 
	MOVLW       150
	MOVWF       R1 
	MOVLW       24
	MOVWF       R2 
	MOVLW       151
	MOVWF       R3 
	CALL        _Div_32x32_FP+0, 0
	MOVLW       0
	MOVWF       R4 
	MOVLW       0
	MOVWF       R5 
	MOVLW       0
	MOVWF       R6 
	MOVLW       127
	MOVWF       R7 
	CALL        _Sub_32x32_FP+0, 0
;usart_PIC18F4550.c,32 :: 		SPBRG = (int)temp;
	CALL        _double2int+0, 0
	MOVF        R0, 0 
	MOVWF       SPBRG+0 
;usart_PIC18F4550.c,43 :: 		TXSTA = 0x20;
	MOVLW       32
	MOVWF       TXSTA+0 
;usart_PIC18F4550.c,54 :: 		RCSTA = 0x90;
	MOVLW       144
	MOVWF       RCSTA+0 
;usart_PIC18F4550.c,55 :: 		}
L_end_UART_Init:
	RETURN      0
; end of _UART_Init

_UART_TX_Idle:

;usart_PIC18F4550.c,56 :: 		char UART_TX_Idle(){
;usart_PIC18F4550.c,57 :: 		return TRMT_bit;
	MOVLW       0
	BTFSC       TRMT_bit+0, BitPos(TRMT_bit+0) 
	MOVLW       1
	MOVWF       R0 
;usart_PIC18F4550.c,58 :: 		}
L_end_UART_TX_Idle:
	RETURN      0
; end of _UART_TX_Idle

_UART_Data_Ready:

;usart_PIC18F4550.c,60 :: 		char UART_Data_Ready(){
;usart_PIC18F4550.c,61 :: 		return RCIF_bit;
	MOVLW       0
	BTFSC       RCIF_bit+0, BitPos(RCIF_bit+0) 
	MOVLW       1
	MOVWF       R0 
;usart_PIC18F4550.c,62 :: 		}
L_end_UART_Data_Ready:
	RETURN      0
; end of _UART_Data_Ready

_UART_Read:

;usart_PIC18F4550.c,63 :: 		char UART_Read(){
;usart_PIC18F4550.c,65 :: 		if(OERR_bit){
	BTFSS       OERR_bit+0, BitPos(OERR_bit+0) 
	GOTO        L_UART_Read0
;usart_PIC18F4550.c,66 :: 		CREN_bit = 0;
	BCF         CREN_bit+0, BitPos(CREN_bit+0) 
;usart_PIC18F4550.c,67 :: 		asm nop;
	NOP
;usart_PIC18F4550.c,68 :: 		CREN_bit = 1;
	BSF         CREN_bit+0, BitPos(CREN_bit+0) 
;usart_PIC18F4550.c,69 :: 		return ERROR;
	MOVLW       255
	MOVWF       R0 
	GOTO        L_end_UART_Read
;usart_PIC18F4550.c,70 :: 		}
L_UART_Read0:
;usart_PIC18F4550.c,72 :: 		while(RCIF_bit == 0);
L_UART_Read1:
	BTFSC       RCIF_bit+0, BitPos(RCIF_bit+0) 
	GOTO        L_UART_Read2
	GOTO        L_UART_Read1
L_UART_Read2:
;usart_PIC18F4550.c,73 :: 		c = RCREG;
	MOVF        RCREG+0, 0 
	MOVWF       R1 
;usart_PIC18F4550.c,75 :: 		if(FERR_bit){
	BTFSS       FERR_bit+0, BitPos(FERR_bit+0) 
	GOTO        L_UART_Read3
;usart_PIC18F4550.c,76 :: 		return ERROR;
	MOVLW       255
	MOVWF       R0 
	GOTO        L_end_UART_Read
;usart_PIC18F4550.c,77 :: 		}
L_UART_Read3:
;usart_PIC18F4550.c,78 :: 		return c;
	MOVF        R1, 0 
	MOVWF       R0 
;usart_PIC18F4550.c,79 :: 		}
L_end_UART_Read:
	RETURN      0
; end of _UART_Read

_UART_Read_ISR:

;usart_PIC18F4550.c,81 :: 		char UART_Read_ISR(){
;usart_PIC18F4550.c,83 :: 		if(RCSTA.OERR){
	BTFSS       RCSTA+0, 1 
	GOTO        L_UART_Read_ISR4
;usart_PIC18F4550.c,84 :: 		RCSTA.CREN = 0;
	BCF         RCSTA+0, 4 
;usart_PIC18F4550.c,85 :: 		asm nop;
	NOP
;usart_PIC18F4550.c,86 :: 		RCSTA.CREN = 1;
	BSF         RCSTA+0, 4 
;usart_PIC18F4550.c,87 :: 		}
L_UART_Read_ISR4:
;usart_PIC18F4550.c,88 :: 		c = RCREG;
	MOVF        RCREG+0, 0 
	MOVWF       R1 
;usart_PIC18F4550.c,89 :: 		if(RCSTA.FERR){
	BTFSS       RCSTA+0, 2 
	GOTO        L_UART_Read_ISR5
;usart_PIC18F4550.c,90 :: 		return ERROR;
	MOVLW       255
	MOVWF       R0 
	GOTO        L_end_UART_Read_ISR
;usart_PIC18F4550.c,91 :: 		}
L_UART_Read_ISR5:
;usart_PIC18F4550.c,92 :: 		return c;
	MOVF        R1, 0 
	MOVWF       R0 
;usart_PIC18F4550.c,93 :: 		}
L_end_UART_Read_ISR:
	RETURN      0
; end of _UART_Read_ISR

_UART_Read_Text:

;usart_PIC18F4550.c,96 :: 		void UART_Read_Text(char *Output, char *Delimiter, char Attempts){
;usart_PIC18F4550.c,97 :: 		int out_length = strlen(Output);
	MOVF        FARG_UART_Read_Text_Output+0, 0 
	MOVWF       FARG_strlen_s+0 
	MOVF        FARG_UART_Read_Text_Output+1, 0 
	MOVWF       FARG_strlen_s+1 
	CALL        _strlen+0, 0
;usart_PIC18F4550.c,98 :: 		int delim_length = strlen(Delimiter);
	MOVF        FARG_UART_Read_Text_Delimiter+0, 0 
	MOVWF       FARG_strlen_s+0 
	MOVF        FARG_UART_Read_Text_Delimiter+1, 0 
	MOVWF       FARG_strlen_s+1 
	CALL        _strlen+0, 0
	MOVF        R0, 0 
	MOVWF       UART_Read_Text_delim_length_L0+0 
	MOVF        R1, 0 
	MOVWF       UART_Read_Text_delim_length_L0+1 
;usart_PIC18F4550.c,100 :: 		if ( !Output || !Delimiter || Attempts <= 0 ) return;
	MOVF        FARG_UART_Read_Text_Output+0, 0 
	IORWF       FARG_UART_Read_Text_Output+1, 0 
	BTFSC       STATUS+0, 2 
	GOTO        L__UART_Read_Text20
	MOVF        FARG_UART_Read_Text_Delimiter+0, 0 
	IORWF       FARG_UART_Read_Text_Delimiter+1, 0 
	BTFSC       STATUS+0, 2 
	GOTO        L__UART_Read_Text20
	MOVF        FARG_UART_Read_Text_Attempts+0, 0 
	SUBLW       0
	BTFSC       STATUS+0, 0 
	GOTO        L__UART_Read_Text20
	GOTO        L_UART_Read_Text8
L__UART_Read_Text20:
	GOTO        L_end_UART_Read_Text
L_UART_Read_Text8:
;usart_PIC18F4550.c,101 :: 		i = 0;
	CLRF        UART_Read_Text_i_L0+0 
;usart_PIC18F4550.c,102 :: 		while(i <= Attempts){
L_UART_Read_Text9:
	MOVF        UART_Read_Text_i_L0+0, 0 
	SUBWF       FARG_UART_Read_Text_Attempts+0, 0 
	BTFSS       STATUS+0, 0 
	GOTO        L_UART_Read_Text10
;usart_PIC18F4550.c,103 :: 		Output[i] = UART_Read();
	MOVF        UART_Read_Text_i_L0+0, 0 
	ADDWF       FARG_UART_Read_Text_Output+0, 0 
	MOVWF       FLOC__UART_Read_Text+0 
	MOVLW       0
	ADDWFC      FARG_UART_Read_Text_Output+1, 0 
	MOVWF       FLOC__UART_Read_Text+1 
	CALL        _UART_Read+0, 0
	MOVFF       FLOC__UART_Read_Text+0, FSR1L+0
	MOVFF       FLOC__UART_Read_Text+1, FSR1H+0
	MOVF        R0, 0 
	MOVWF       POSTINC1+0 
;usart_PIC18F4550.c,104 :: 		Output[++i] = '\0';
	INCF        UART_Read_Text_i_L0+0, 1 
	MOVF        UART_Read_Text_i_L0+0, 0 
	ADDWF       FARG_UART_Read_Text_Output+0, 0 
	MOVWF       FSR1L+0 
	MOVLW       0
	ADDWFC      FARG_UART_Read_Text_Output+1, 0 
	MOVWF       FSR1L+1 
	CLRF        POSTINC1+0 
;usart_PIC18F4550.c,105 :: 		if ( i >= delim_length && strcmp(&Output[i - delim_length], Delimiter) == 0){
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       UART_Read_Text_delim_length_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__UART_Read_Text27
	MOVF        UART_Read_Text_delim_length_L0+0, 0 
	SUBWF       UART_Read_Text_i_L0+0, 0 
L__UART_Read_Text27:
	BTFSS       STATUS+0, 0 
	GOTO        L_UART_Read_Text13
	MOVF        UART_Read_Text_delim_length_L0+0, 0 
	SUBWF       UART_Read_Text_i_L0+0, 0 
	MOVWF       R0 
	MOVF        UART_Read_Text_delim_length_L0+1, 0 
	MOVWF       R1 
	MOVLW       0
	SUBFWB      R1, 1 
	MOVF        R0, 0 
	ADDWF       FARG_UART_Read_Text_Output+0, 0 
	MOVWF       FARG_strcmp_s1+0 
	MOVF        R1, 0 
	ADDWFC      FARG_UART_Read_Text_Output+1, 0 
	MOVWF       FARG_strcmp_s1+1 
	MOVF        FARG_UART_Read_Text_Delimiter+0, 0 
	MOVWF       FARG_strcmp_s2+0 
	MOVF        FARG_UART_Read_Text_Delimiter+1, 0 
	MOVWF       FARG_strcmp_s2+1 
	CALL        _strcmp+0, 0
	MOVLW       0
	XORWF       R1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__UART_Read_Text28
	MOVLW       0
	XORWF       R0, 0 
L__UART_Read_Text28:
	BTFSS       STATUS+0, 2 
	GOTO        L_UART_Read_Text13
L__UART_Read_Text19:
;usart_PIC18F4550.c,106 :: 		Output[i - delim_length] = '\0';
	MOVF        UART_Read_Text_delim_length_L0+0, 0 
	SUBWF       UART_Read_Text_i_L0+0, 0 
	MOVWF       R0 
	MOVF        UART_Read_Text_delim_length_L0+1, 0 
	MOVWF       R1 
	MOVLW       0
	SUBFWB      R1, 1 
	MOVF        R0, 0 
	ADDWF       FARG_UART_Read_Text_Output+0, 0 
	MOVWF       FSR1L+0 
	MOVF        R1, 0 
	ADDWFC      FARG_UART_Read_Text_Output+1, 0 
	MOVWF       FSR1L+1 
	CLRF        POSTINC1+0 
;usart_PIC18F4550.c,107 :: 		break;
	GOTO        L_UART_Read_Text10
;usart_PIC18F4550.c,108 :: 		}
L_UART_Read_Text13:
;usart_PIC18F4550.c,109 :: 		}
	GOTO        L_UART_Read_Text9
L_UART_Read_Text10:
;usart_PIC18F4550.c,110 :: 		return;
;usart_PIC18F4550.c,111 :: 		}
L_end_UART_Read_Text:
	RETURN      0
; end of _UART_Read_Text

_UART_Write:

;usart_PIC18F4550.c,113 :: 		void UART_Write(char Tx_data){
;usart_PIC18F4550.c,114 :: 		while(TXIF_bit == 0);
L_UART_Write14:
	BTFSC       TXIF_bit+0, BitPos(TXIF_bit+0) 
	GOTO        L_UART_Write15
	GOTO        L_UART_Write14
L_UART_Write15:
;usart_PIC18F4550.c,115 :: 		TXREG = Tx_data;
	MOVF        FARG_UART_Write_Tx_data+0, 0 
	MOVWF       TXREG+0 
;usart_PIC18F4550.c,116 :: 		return;
;usart_PIC18F4550.c,117 :: 		}
L_end_UART_Write:
	RETURN      0
; end of _UART_Write

_UART_Write_Text:

;usart_PIC18F4550.c,119 :: 		void UART_Write_Text(char *UART_text){
;usart_PIC18F4550.c,120 :: 		if( !UART_text ) return;
	MOVF        FARG_UART_Write_Text_UART_text+0, 0 
	IORWF       FARG_UART_Write_Text_UART_text+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L_UART_Write_Text16
	GOTO        L_end_UART_Write_Text
L_UART_Write_Text16:
;usart_PIC18F4550.c,121 :: 		while( *UART_text != '\0' ){
L_UART_Write_Text17:
	MOVFF       FARG_UART_Write_Text_UART_text+0, FSR0L+0
	MOVFF       FARG_UART_Write_Text_UART_text+1, FSR0H+0
	MOVF        POSTINC0+0, 0 
	XORLW       0
	BTFSC       STATUS+0, 2 
	GOTO        L_UART_Write_Text18
;usart_PIC18F4550.c,122 :: 		UART_Write(*UART_text);
	MOVFF       FARG_UART_Write_Text_UART_text+0, FSR0L+0
	MOVFF       FARG_UART_Write_Text_UART_text+1, FSR0H+0
	MOVF        POSTINC0+0, 0 
	MOVWF       FARG_UART_Write_Tx_data+0 
	CALL        _UART_Write+0, 0
;usart_PIC18F4550.c,123 :: 		UART_text++;
	INFSNZ      FARG_UART_Write_Text_UART_text+0, 1 
	INCF        FARG_UART_Write_Text_UART_text+1, 1 
;usart_PIC18F4550.c,124 :: 		}
	GOTO        L_UART_Write_Text17
L_UART_Write_Text18:
;usart_PIC18F4550.c,125 :: 		return;
;usart_PIC18F4550.c,126 :: 		}
L_end_UART_Write_Text:
	RETURN      0
; end of _UART_Write_Text
