#include "myStdlib.h"
char* my_itoa(int value, char* str, int base)
{
    char* ptr = str;
    char* ptr1 = str;
    char tmp_char;
    int tmp_value;

    // x? lý s? âm
    if(value < 0 && base == 10){
        value = -value;
        *ptr++ = '-';
        ptr1++;
    }

    // t?o chu?i ngu?c
    do {
        tmp_value = value;
        value /= base;
        *ptr++ = (tmp_value - value * base) + '0';
    } while(value);

    *ptr-- = '\0';

    // d?o chu?i
    while(ptr1 < ptr){
        tmp_char = *ptr;
        *ptr-- = *ptr1;
        *ptr1++ = tmp_char;
    }

    return str;
}
