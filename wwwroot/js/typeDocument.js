var btn_1 = document.getElementById('btn_1');
var btn_2 = document.getElementById('btn_2');
var btn_3 = document.getElementById('btn_3');
var btn_4 = document.getElementById('btn_4');
var btnType = document.getElementById('btnType');

function agregarValor(valor){
    btnType.value = valor;
    console.log(btnType.value)
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