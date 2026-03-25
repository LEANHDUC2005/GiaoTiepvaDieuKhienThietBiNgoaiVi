#include "usart_PIC18F4550.h"
#include <string.h>
/*
TXSTA
7    6    5    4    3    2    1    0
CSRC TX9 TXEN SYNC SENDB BRGH TRMT TX9D
*/

/*
RCSTA
7    6    5    4    3    2    1    0
SPEN RX9 SREN CREN ADDEN FERR OERR RX9D
*/
// Function
//void UART_Init(const unsigned long baud_rate);
//char UART_Data_Ready();
//char UART_TX_Idle();
//char UART_Read();
//void UART_Read_Text(char *Output, char *Delimiter, char Attempts);
//char UART_Read();
//void UART_Write(char Tx_data);
//void UART_Write_Text(char *UART_text);

void UART_Init(const unsigned long baud_rate)
{
    float temp;
    // Active TX and RX
    TRISC6_bit = 0; // TX
    TRISC7_bit = 1; // RX
    // Low speed Baud Rate
    temp = ((float)F_CPU / (64 * (float)baud_rate) - 1);
    SPBRG = (int)temp;
    /* TXSTA register
    TXSTA.CSRC_bit = 0;
    TXSTA.TX9_bit = 0;
    TXSTA.TXEN_bit = 1;
    TXSTA.SYNC_bit = 0;
    TXSTA.SENDB_bit = 0;
    TXSTA.BRGH_bit = 0;
    TXSTA.TRMT_bit = 0;     hardware bit
    TXSTA.TX9D_bit = 0;
    */
    TXSTA = 0x20;
    /* RCSTA register
    RCSTA.SPEN_bit = 1;
    RCSTA.RX9_bit = 0;
    RCSTA.SREN_bit = 0;
    RCSTA.CREN_bit = 1;
    RCSTA.ADDEN_bit = 0;
    RCSTA.FERR_bit = 0;      hardware bit
    RCSTA.OERR_bit = 0;      hardware bit
    TXSTA.TX9D_bit = 0;
    */
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
         return ERROR;
     }
     
     while(RCIF_bit == 0);
     c = RCREG;
     
     if(FERR_bit){
        return ERROR;
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
        return ERROR;
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