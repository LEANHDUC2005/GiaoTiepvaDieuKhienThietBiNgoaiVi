#pragma once
#define ERROR -1
#define F_CPU 20000000
void UART_Init(const unsigned long baud_rate);
char UART_Data_Ready();
char UART_TX_Idle();
char UART_Read();
void UART_Read_Text(char *Output, char *Delimiter, char Attempts);
char UART_Read_ISR();
void UART_Write(char Tx_data);
void UART_Write_Text(char *UART_text);