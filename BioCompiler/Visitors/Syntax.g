grammar Syntax;


program
    : stat* EOF
    ;

stat
    : repeat
    | input
    | declaration
    | move
    | merge
    | split    
    | mix
    | output
    | store
    ;

repeat
    : 'repeat' INT 'times{' stat* '}'
    ;

declaration
    : 'droplet' ID ';'
    ;

input
    : 'input(' ID ',' INT ',' INT ',' FLOAT ')' ';'
    ;


move
    : 'move' '(' ID',' INT ',' INT ')' ';'
    ;

merge
    : 'merge' '(' ID ',' ID ',' ID ',' INT ',' INT ')' ';'
    ;

split
    : 'split' '(' ID ',' ID ',' ID ',' INT ',' INT ','INT ',' INT ','FLOAT')'';'
    ;

mix
    : 'mix' '(' ID ',' INT ',' INT ',' INT ',' INT ',' INT ')' ';' 
    ;

output
    : 'output' '(' ID ',' INT ',' INT ')' ';'
    ;

store
    : 'store' '(' ID ',' INT ',' INT ',' FLOAT ')' ';'
    ;

ID
 : [a-zA-Z_] [a-zA-Z_0-9]*
 ;
    
INT 
    :    [0-9]+
    ;
FLOAT
    :    INT '.' INT
    ;

COMMENT
 : '#' ~[\r\n]* -> skip
 ;

SPACE
 : [ \t\r\n] -> skip
 ;


