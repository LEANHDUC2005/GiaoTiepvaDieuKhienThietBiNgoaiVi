#line 1 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/usart_PIC18F4550.c"
#line 1 "d:/file hoc tap/giaotiepvadieukhienthietbingoaivi_firmware/lab1/usart_pic18f4550.h"



void UART_Init(const unsigned long baud_rate);
char UART_Data_Ready();
char UART_TX_Idle();
char UART_Read();
void UART_Read_Text(char *Output, char *Delimiter, char Attempts);
char UART_Read_ISR();
void UART_Write(char Tx_data);
void UART_Write_Text(char *UART_text);
#line 1 "d:/mikroc pro for pic/include/string.h"





void * memchr(void *p, char n, unsigned int v);
int memcmp(void *s1, void *s2, int n);
void * memcpy(void * d1, void * s1, int n);
void * memmove(void * to, void * from, int n);
void * memset(void * p1, char character, int n);
char * strcat(char * to, char * from);
char * strchr(char * ptr, char chr);
int strcmp(char * s1, char * s2);
char * strcpy(char * to, char * from);
int strlen(char * s);
char * strncat(char * to, char * from, int size);
char * strncpy(char * to, char * from, int size);
int strspn(char * str1, char * str2);
char strcspn(char * s1, char * s2);
int strncmp(char * s1, char * s2, char len);
char * strpbrk(char * s1, char * s2);
char * strrchr(char *ptr, char chr);
char * strstr(char * s1, char * s2);
char * strtok(char * s1, char * s2);
#line 24 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/usart_PIC18F4550.c"
void UART_Init(const unsigned long baud_rate)
{
 float temp;

 TRISC6_bit = 0;
 TRISC7_bit = 1;

 temp = ((float) 20000000  / (64 * (float)baud_rate) - 1);
 SPBRG = (int)temp;
#line 43 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/usart_PIC18F4550.c"
 TXSTA = 0x20;
#line 54 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/usart_PIC18F4550.c"
 RCSTA = 0x90;
}
char UART_TX_Idle(){
 return TRMT_bit;
}

char UART_Data_Ready(){
 return RCIF_bit;
}
char UART_Read(){
 char c;
 if(OERR_bit){
 CREN_bit = 0;
 asm nop;
 CREN_bit = 1;
 return  -1 ;
 }

 while(RCIF_bit == 0);
 c = RCREG;

 if(FERR_bit){
 return  -1 ;
 }
 return c;
}

char UART_Read_ISR(){
 char c;
 if(RCSTA.OERR){
 RCSTA.CREN = 0;
 asm nop;
 RCSTA.CREN = 1;
 }
 c = RCREG;
 if(RCSTA.FERR){
 return  -1 ;
 }
 return c;
}


void UART_Read_Text(char *Output, char *Delimiter, char Attempts){
 int out_length = strlen(Output);
 int delim_length = strlen(Delimiter);
 char i;
 if ( !Output || !Delimiter || Attempts <= 0 ) return;
 i = 0;
 while(i <= Attempts){
 Output[i] = UART_Read();
 Output[++i] = '\0';
 if ( i >= delim_length && strcmp(&Output[i - delim_length], Delimiter) == 0){
 Output[i - delim_length] = '\0';
 break;
 }
 }
 return;
}

void UART_Write(char Tx_data){
 while(TXIF_bit == 0);
 TXREG = Tx_data;
 return;
}

void UART_Write_Text(char *UART_text){
 if( !UART_text ) return;
 while( *UART_text != '\0' ){
 UART_Write(*UART_text);
 UART_text++;
 }
 return;
}
