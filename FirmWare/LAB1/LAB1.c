#define LED_ON   1
#define LED_OFF  0
#define RX_MAX   12
#define TX_MAX   12
unsigned char transmitData[TX_MAX + 1];
unsigned char receiveData[RX_MAX + 1];
unsigned char frameLocal[RX_MAX + 1];
unsigned char frameSW[RX_MAX + 1];
typedef enum{
    ON,
    OFF,
    NONE,
}LED_state;

typedef enum{
    IDLE,
    RECEIVING,
}state;

LED_state LED_State = NONE;
state State = IDLE;

volatile unsigned char frameComplete = 0;
volatile unsigned char SW_RB0_Pressed = 0;
volatile unsigned char receiveIndex = 0;
volatile unsigned int countSW = 0;


void interrupt(){
     if(INTCON3.INT1IF){
         INTCON3.INT1IF = 0;
         LATE.LATE0 = ~LATE.LATE0;
         if(PORTB.RB2 == 1)
              LED_State = OFF;
         else
              LED_State = ON;
     }

     else if(INTCON.INT0IF){
         INTCON.INT0IF = 0;
         if(countSW > 255) countSW = 0;
         countSW++;
         SW_RB0_Pressed = 1;
     }

     else if(INTCON3.INT2IF){
          INTCON3.INT2IF = 0;
     }
    
     else if(PIR1.RCIF){
         char c = UART_Read();
         switch(State){
             case IDLE:
                 if(c == '@'){
                    receiveIndex = 0;
                    receiveData[receiveIndex++] = c;
                    State = RECEIVING;
                 }
                 break;
             case RECEIVING:
                 if(receiveIndex < RX_MAX){
                    receiveData[receiveIndex++] = c;
                 }
                 else{
                    receiveIndex = 0;
                    State = IDLE;
                    break;
                 }
                 if(c == '&'){
                    receiveData[receiveIndex] = '\0';
                    frameComplete = 1;
                    State = IDLE;
                 }
                 break;
             default: break;
         }
     }
}

void ioInit(){
    // Digital I/O
    ADCON1 = 0x0F;
    CMCON = 0x07;
    
    // Input
    TRISB.TRISB0 = 1;
    TRISB.TRISB1 = 1;
    TRISB.TRISB2 = 1;
    INTCON2.RBPU = 0x07;
    
    
    // Output
    PORTE.RE0 = 0;
    PORTE.RE1 = 0;
    TRISE.TRISE0 = 0;
    TRISE.TRISE1 = 0;
    LATE = 0;
    
    // Interrupt
    INTCON.INT0IE = 1; // SW0
    INTCON.INT0IF = 0;
    INTCON2.INTEDG0 = 1;
    
    INTCON3.INT1IE = 1;  // SW1
    INTCON3.INT1IF = 0;
    INTCON2.INTEDG1 = 1;

    INTCON2.INTEDG2 = 1; // ngat canh len
    INTCON3.INT2IF = 0;  // clear flag
    INTCON3.INT2IE = 1;  // enable INT2
    
    PIE1.RCIE = 1;
    PIE1.TXIE = 0;     // UART
    INTCON.PEIE = 1;
    INTCON.GIE = 1;
}

void main(){
     ioInit();
     UART1_Init(9600);
     delay_ms(100);
     while(1){
          if(SW_RB0_Pressed){
                 sprintf(transmitData, "@S%d&", countSW);
                 UART_Write_Text(transmitData);
                 SW_RB0_Pressed = 0;
          }
        
          else if(frameComplete){
               strcpy(frameLocal, receiveData);
               if(strcmp("@le_on&", frameLocal) == 0){
                    LATE.LATE1 = LED_ON;
                    UART_Write_Text("@Lle_on&");
               }
               else if(strcmp("@le_of&", frameLocal) == 0){
                    LATE.LATE1 = LED_OFF;
                    UART_Write_Text("@Lle_of&");
               }
               else if(strcmp("@le+_on&", frameLocal) == 0){
                    LATE.LATE0 = LED_ON;
                    if(PORTB.RB2 == 1){
                         UART_Write_Text("@Lle+_of&");
                    }
                    else{
                         UART_Write_Text("@Lle+_on&");
                    }
               }
               else if(strcmp("@le+_of&", frameLocal) == 0){
                    LATE.LATE0 = LED_OFF;
                    if(PORTB.RB2 == 1){
                         UART_Write_Text("@Lle+_of&");
                    }
                    else{
                         UART_Write_Text("@Lle+_on&");
                    }
               }
               else{
                    UART_Write_Text("@Error&");
               }
               frameComplete = 0;
          }
          
         switch(LED_State){
              case ON:
                   UART_Write_Text("@Lle+_on&");
                   LED_State = NONE;
                   break;

              case OFF:
                   UART_Write_Text("@Lle+_of&");
                   LED_State = NONE;
                   break;

              case NONE: break;
         }
    }
}