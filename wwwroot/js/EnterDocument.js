

var btn_1 = document.getElementById('btn_1');
var btn_2 = document.getElementById('btn_2');
var btn_3 = document.getElementById('btn_3');
var btn_4 = document.getElementById('btn_4');
var btn_5 = document.getElementById('btn_5');
var btn_6 = document.getElementById('btn_6');
var btn_7 = document.getElementById('btn_7');
var btn_8 = document.getElementById('btn_8');
var btn_9 = document.getElementById('btn_9');
var btn_0 = document.getElementById('btn_0');
var btn_Clear = document.getElementById('btn_Clear');
var Documento = document.getElementById('Documento');

var newvalor = false;
var array = [];
var contador = 0;

function agregarValor(valor) {
    array.push(valor); 
    contador++;
    Documento.value = array.join(' '); 
    console.log(Documento.value);
}

btn_1.addEventListener('click', () => {
    agregarValor(1);
});

btn_2.addEventListener('click', () => {
    agregarValor(2);
});

btn_3.addEventListener('click', () => {
    agregarValor(3);
});

btn_4.addEventListener('click', () => {
    agregarValor(4);
});

btn_5.addEventListener('click', () => {
    agregarValor(5);
});

btn_6.addEventListener('click', () => {
    agregarValor(6);
});

btn_7.addEventListener('click', () => {
    agregarValor(7);
});

btn_8.addEventListener('click', () => {
    agregarValor(8);
});

btn_9.addEventListener('click', () => {
    agregarValor(9);
});

btn_0.addEventListener('click', () => {
    agregarValor(0);
});

    btn_Clear.addEventListener('click', () => {
        array = []; 
        Documento.value = "";
    });
