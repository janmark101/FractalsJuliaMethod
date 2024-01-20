.data
two dq 2.0
half dq 0.5
onehalf dq 1.5
maxIterations dq 1000
four dq 4
nine dq 9.0
one dq 1.0
twofivefive dq 255.0
eighthalf dq 8.5
onefive dq 15.0
three dq 3
myInt dd 4
szerokosc dq 858
wysokosc dq 475
maxIterations2 dq 1000.0
stride dq 3432


.code
MyProc2 PROC


    xor rax, rax            ; Clear rax to store temporary values
    mov rbx, [szerokosc]  ; width to rbx
    mov r10d, [myInt] ; number 4 too r10d
    mov r9, [wysokosc] ; height to r9
    imul rbx, r10  ; sszerokosc * 4 = te stride
    
    ;xmm1 cx
    ;xmm2 cy
    xor rax,rax ; jako x ? 
    xor r12, r12 ; jako y ?


outer_loop: ; wysokosc -> x
    mov R11, 0          ; tu po wysokosci rax ma licznik x 
    mov r12, 0

inner_loop: ;szerokosc -> y

    cvtsi2sd xmm8, rax ; zamiana x na double
    movsd xmm12, xmm8 ; x 
 
    

    cvtsi2sd xmm10, r12 ; zamiana y na double
    movsd xmm4, xmm10 ; y



    cvtsi2sd xmm9 ,[szerokosc] ; zamiana width na double 


    movsd xmm6, xmm9 ;  width do xmm6
    mulsd xmm6, [half] ; width / 2 

    cvtsi2sd xmm11 ,r9 ; zamiana heigth na double

    movsd xmm7, xmm11 ;  height do xmm7
    ;mulsd xmm7, [half] ; height / 2 



    subsd xmm4,  xmm6 ; x - width /2

    mulsd xmm4, [onehalf]
    divsd xmm4, xmm6  ; zx !!!
    


    subsd xmm12,  xmm7 ; y - height /2

    

    divsd xmm12, xmm7  ; zy !!!

 mov rdx, 0 ; iteration

while_loop:

    movsd xmm6, xmm12
    unpcklpd xmm6, xmm4
    mulpd xmm6, xmm6 ; w  gornej czesci zx^2 w dolnej zy^2
    movhlps xmm10, xmm6
    addsd xmm10, xmm6

    cvttsd2si r13, xmm10 ; temp doo inta

    cmp  r13, [four]
    ja end_while  ; SPRAWDZIC TO JAK BY NIE DZIALALO 

    cmp rdx, [maxIterations]
    jge end_while ; SPRAWDZIC TO JAK BY NIE DZIALALO

    xorps xmm10, xmm10
    movhlps xmm10, xmm6
    subsd xmm10, xmm6
    addsd xmm10, xmm1 ; zx^2 - zy^2 + cX  TMP

    mulsd xmm12, xmm4 ; zy * zx
    mulsd xmm12, [two]; zy*zx*2
    addsd xmm12, xmm2 ; zy*zx*2+cY ZY 

    movsd xmm4, xmm10 ; zx = temp 

    inc rdx
    jmp while_loop


end_while:
    cmp rdx, [maxIterations] 
    jne not_equal
    
    mov byte ptr [rcx + r11] , 0
    mov byte ptr [rcx + r11 + 1] , 255
    mov byte ptr [rcx + r11 + 2] , 0
    mov byte ptr [rcx + r11 + 3] , 255
    jmp continue_loop

not_equal:

    cvtsi2sd xmm3, rdx ; zamiania iteration na double
    movsd xmm5, [maxIterations2]
    divsd xmm3, xmm5 ; iteration / maxiterationss  -> ratio
       

    movsd xmm5, [one]
    subsd xmm5, xmm3
    mulsd xmm5, [nine]
    mulsd xmm5, xmm3
    mulsd xmm5, xmm3 ; ziutek sie jebie tu 
    mulsd xmm5, xmm3
    mulsd xmm5, [twofivefive] ; double red

    cvttsd2si r13, xmm5

    mov byte ptr [rcx + r11] , r13b

    ;cvtsd2si eax, xmm5          ; Konwersja do int, wynik w eax

    movsd xmm14, [one]
    subsd xmm14, xmm3
    mulsd xmm14, xmm14
    mulsd xmm14, [onefive]
    mulsd xmm14, xmm3
    mulsd xmm14, xmm3 ; ten ziutek pierdoli
    mulsd xmm14, [twofivefive] ; double green

    cvttsd2si r13, xmm14


    mov byte ptr [rcx + r11 + 1] , r13b

    movsd xmm13, [one]
    subsd xmm13, xmm3
    movsd xmm12, xmm13
    mulsd xmm13, xmm13 
    mulsd xmm13, xmm12
    mulsd xmm13, [eighthalf]
    mulsd xmm13, xmm3
    mulsd xmm13, [twofivefive] ; double blue

    cvttsd2si r13, xmm13
 
    mov byte ptr [rcx + r11 + 2] , r13b

    mov byte ptr [rcx + r11 + 3] , 255


continue_loop:   
    ; Update resultIndex
    add R11, R10  ; licznik pixeli 
    inc r12 


    ; Continue inner loop
    cmp R11, rbx ; sprawdzienie czy caly wierssz pixeli przeszlo
    jl inner_loop

    ; Update pointers for the next row
    add rcx, rbx ; ustawienie wskaznika tablicy na kolejny wiersz pixeli


    ; Continue outer loop
    inc rax ; rax jako y
    dec r9  ; odejmuje az dojdzie do 0
    jnz outer_loop ; jesli wieksze niz 0 to skok 
    


    ret ; jesli 0 to wypierdala



    
MyProc2 ENDP


MyProc3 PROC
    
   

    ;r9 jest x 
    mov r10, [rsp + 40] ;y 
    ; xmm1 cx
    ; xmm2 cy
    mov r12, qword ptr [stride]

    mov rax, r9
    imul rax, 4
    mov r11, r10
    imul r11, r12
    add rax, r11



    cvtsi2sd xmm8, r9 ; zamiana x na double
    movsd xmm4, xmm8 ; x 
 
    

    cvtsi2sd xmm10, r10 ; zamiana y na double
    movsd xmm12, xmm10 ; y



    cvtsi2sd xmm9 ,[szerokosc] ; zamiana width na double 


    movsd xmm6, xmm9 ;  width do xmm6
    mulsd xmm6, [half] ; width / 2 

    cvtsi2sd xmm11 ,[wysokosc] ; zamiana heigth na double

    movsd xmm7, xmm11 ;  height do xmm7
    mulsd xmm7, [half] ; height / 2 



    subsd xmm4,  xmm6 ; x - width /2

    mulsd xmm4, [onehalf]
    divsd xmm4, xmm6  ; zx !!!
    


    subsd xmm12,  xmm7 ; y - height /2

    

    divsd xmm12, xmm7  ; zy !!!

 mov rdx, 0 ; iteration

while_loop:

    movsd xmm6, xmm12
    unpcklpd xmm6, xmm4
    mulpd xmm6, xmm6 ; w  gornej czesci zx^2 w dolnej zy^2
    movhlps xmm10, xmm6
    addsd xmm10, xmm6

    cvttsd2si r13, xmm10 ; temp doo inta

    cmp  r13, [four]
    ja end_while  ; SPRAWDZIC TO JAK BY NIE DZIALALO 

    cmp rdx, [maxIterations]
    jge end_while ; SPRAWDZIC TO JAK BY NIE DZIALALO

    xorps xmm10, xmm10
    movhlps xmm10, xmm6
    subsd xmm10, xmm6
    addsd xmm10, xmm1 ; zx^2 - zy^2 + cX  TMP

    mulsd xmm12, xmm4 ; zy * zx
    mulsd xmm12, [two]; zy*zx*2
    addsd xmm12, xmm2 ; zy*zx*2+cY ZY 

    movsd xmm4, xmm10 ; zx = temp 

    inc rdx
    jmp while_loop


end_while:
    cmp rdx, [maxIterations] 
    jne not_equal
    
    mov byte ptr [rcx + rax] , 0
    mov byte ptr [rcx + rax + 1] , 255
    mov byte ptr [rcx + rax + 2] , 0
    mov byte ptr [rcx + rax + 3] , 255


not_equal:

    cvtsi2sd xmm3, rdx ; zamiania iteration na double
    movsd xmm5, [maxIterations2]
    divsd xmm3, xmm5 ; iteration / maxiterationss  -> ratio
       

    movsd xmm5, [one]
    subsd xmm5, xmm3
    mulsd xmm5, [nine]
    mulsd xmm5, xmm3
    mulsd xmm5, xmm3 ; ziutek sie jebie tu 
    mulsd xmm5, xmm3
    mulsd xmm5, [twofivefive] ; double red

    cvttsd2si r13, xmm5

    mov byte ptr [rcx + rax] , r13b

    ;cvtsd2si eax, xmm5          ; Konwersja do int, wynik w eax

    movsd xmm14, [one]
    subsd xmm14, xmm3
    mulsd xmm14, xmm14
    mulsd xmm14, [onefive]
    mulsd xmm14, xmm3
    mulsd xmm14, xmm3 ; ten ziutek pierdoli
    mulsd xmm14, [twofivefive] ; double green

    cvttsd2si r13, xmm14


    mov byte ptr [rcx + rax + 1] , r13b

    movsd xmm13, [one]
    subsd xmm13, xmm3
    movsd xmm12, xmm13
    mulsd xmm13, xmm13 
    mulsd xmm13, xmm12
    mulsd xmm13, [eighthalf]
    mulsd xmm13, xmm3
    mulsd xmm13, [twofivefive] ; double blue

    cvttsd2si r13, xmm13
 
    mov byte ptr [rcx + rax + 2] , r13b

    mov byte ptr [rcx + rax + 3] , 255



    ret
MyProc3 ENDP

END