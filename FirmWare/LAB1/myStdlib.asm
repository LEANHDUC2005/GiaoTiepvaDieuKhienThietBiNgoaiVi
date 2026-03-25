
_my_itoa:

;myStdlib.c,2 :: 		char* my_itoa(int value, char* str, int base)
;myStdlib.c,4 :: 		char* ptr = str;
	MOVF        FARG_my_itoa_str+0, 0 
	MOVWF       my_itoa_ptr_L0+0 
	MOVF        FARG_my_itoa_str+1, 0 
	MOVWF       my_itoa_ptr_L0+1 
;myStdlib.c,5 :: 		char* ptr1 = str;
	MOVF        FARG_my_itoa_str+0, 0 
	MOVWF       my_itoa_ptr1_L0+0 
	MOVF        FARG_my_itoa_str+1, 0 
	MOVWF       my_itoa_ptr1_L0+1 
;myStdlib.c,10 :: 		if(value < 0 && base == 10){
	MOVLW       128
	XORWF       FARG_my_itoa_value+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__my_itoa10
	MOVLW       0
	SUBWF       FARG_my_itoa_value+0, 0 
L__my_itoa10:
	BTFSC       STATUS+0, 0 
	GOTO        L_my_itoa2
	MOVLW       0
	XORWF       FARG_my_itoa_base+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__my_itoa11
	MOVLW       10
	XORWF       FARG_my_itoa_base+0, 0 
L__my_itoa11:
	BTFSS       STATUS+0, 2 
	GOTO        L_my_itoa2
L__my_itoa8:
;myStdlib.c,11 :: 		value = -value;
	MOVF        FARG_my_itoa_value+0, 0 
	SUBLW       0
	MOVWF       FARG_my_itoa_value+0 
	MOVF        FARG_my_itoa_value+1, 0 
	MOVWF       FARG_my_itoa_value+1 
	MOVLW       0
	SUBFWB      FARG_my_itoa_value+1, 1 
;myStdlib.c,12 :: 		*ptr++ = '-';
	MOVFF       my_itoa_ptr_L0+0, FSR1L+0
	MOVFF       my_itoa_ptr_L0+1, FSR1H+0
	MOVLW       45
	MOVWF       POSTINC1+0 
	INFSNZ      my_itoa_ptr_L0+0, 1 
	INCF        my_itoa_ptr_L0+1, 1 
;myStdlib.c,13 :: 		ptr1++;
	INFSNZ      my_itoa_ptr1_L0+0, 1 
	INCF        my_itoa_ptr1_L0+1, 1 
;myStdlib.c,14 :: 		}
L_my_itoa2:
;myStdlib.c,17 :: 		do {
L_my_itoa3:
;myStdlib.c,18 :: 		tmp_value = value;
	MOVF        FARG_my_itoa_value+0, 0 
	MOVWF       my_itoa_tmp_value_L0+0 
	MOVF        FARG_my_itoa_value+1, 0 
	MOVWF       my_itoa_tmp_value_L0+1 
;myStdlib.c,19 :: 		value /= base;
	MOVF        FARG_my_itoa_base+0, 0 
	MOVWF       R4 
	MOVF        FARG_my_itoa_base+1, 0 
	MOVWF       R5 
	MOVF        FARG_my_itoa_value+0, 0 
	MOVWF       R0 
	MOVF        FARG_my_itoa_value+1, 0 
	MOVWF       R1 
	CALL        _Div_16x16_S+0, 0
	MOVF        R0, 0 
	MOVWF       FARG_my_itoa_value+0 
	MOVF        R1, 0 
	MOVWF       FARG_my_itoa_value+1 
;myStdlib.c,20 :: 		*ptr++ = (tmp_value - value * base) + '0';
	MOVF        R0, 0 
	MULWF       FARG_my_itoa_base+0 
	MOVF        PRODL+0, 0 
	MOVWF       R0 
	MOVF        R0, 0 
	SUBWF       my_itoa_tmp_value_L0+0, 0 
	MOVWF       R0 
	MOVFF       my_itoa_ptr_L0+0, FSR1L+0
	MOVFF       my_itoa_ptr_L0+1, FSR1H+0
	MOVLW       48
	ADDWF       R0, 0 
	MOVWF       POSTINC1+0 
	INFSNZ      my_itoa_ptr_L0+0, 1 
	INCF        my_itoa_ptr_L0+1, 1 
;myStdlib.c,21 :: 		} while(value);
	MOVF        FARG_my_itoa_value+0, 0 
	IORWF       FARG_my_itoa_value+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L_my_itoa3
;myStdlib.c,23 :: 		*ptr-- = '\0';
	MOVFF       my_itoa_ptr_L0+0, FSR1L+0
	MOVFF       my_itoa_ptr_L0+1, FSR1H+0
	CLRF        POSTINC1+0 
	MOVLW       1
	SUBWF       my_itoa_ptr_L0+0, 1 
	MOVLW       0
	SUBWFB      my_itoa_ptr_L0+1, 1 
;myStdlib.c,26 :: 		while(ptr1 < ptr){
L_my_itoa6:
	MOVF        my_itoa_ptr_L0+1, 0 
	SUBWF       my_itoa_ptr1_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__my_itoa12
	MOVF        my_itoa_ptr_L0+0, 0 
	SUBWF       my_itoa_ptr1_L0+0, 0 
L__my_itoa12:
	BTFSC       STATUS+0, 0 
	GOTO        L_my_itoa7
;myStdlib.c,27 :: 		tmp_char = *ptr;
	MOVFF       my_itoa_ptr_L0+0, FSR0L+0
	MOVFF       my_itoa_ptr_L0+1, FSR0H+0
	MOVF        POSTINC0+0, 0 
	MOVWF       my_itoa_tmp_char_L0+0 
;myStdlib.c,28 :: 		*ptr-- = *ptr1;
	MOVFF       my_itoa_ptr1_L0+0, FSR0L+0
	MOVFF       my_itoa_ptr1_L0+1, FSR0H+0
	MOVFF       my_itoa_ptr_L0+0, FSR1L+0
	MOVFF       my_itoa_ptr_L0+1, FSR1H+0
	MOVF        POSTINC0+0, 0 
	MOVWF       POSTINC1+0 
	MOVLW       1
	SUBWF       my_itoa_ptr_L0+0, 1 
	MOVLW       0
	SUBWFB      my_itoa_ptr_L0+1, 1 
;myStdlib.c,29 :: 		*ptr1++ = tmp_char;
	MOVFF       my_itoa_ptr1_L0+0, FSR1L+0
	MOVFF       my_itoa_ptr1_L0+1, FSR1H+0
	MOVF        my_itoa_tmp_char_L0+0, 0 
	MOVWF       POSTINC1+0 
	INFSNZ      my_itoa_ptr1_L0+0, 1 
	INCF        my_itoa_ptr1_L0+1, 1 
;myStdlib.c,30 :: 		}
	GOTO        L_my_itoa6
L_my_itoa7:
;myStdlib.c,32 :: 		return str;
	MOVF        FARG_my_itoa_str+0, 0 
	MOVWF       R0 
	MOVF        FARG_my_itoa_str+1, 0 
	MOVWF       R1 
;myStdlib.c,33 :: 		}
L_end_my_itoa:
	RETURN      0
; end of _my_itoa
