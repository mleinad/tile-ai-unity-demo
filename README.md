Para a geração do mar foi utilizada o algoritmo de Perlin Noise e a sua função matematica para gerar as alturas do terreno.
O xcoord e o ycoord são as coordenadas utilizadas para calcular o Perlin Noise.
A relação entre o tamanho do terreno ('width' e 'height) a escala ('scale') e os desvios ('offsetX' e 'offsetY') aleatórios, permitem que o resultado da funcao de Perlin seja variavel, e assim, fazer com que o terreno tenha padrões diferentes.
O resultado da função Perlin devolve o valor entre 0 e 1, cada ponto do terreno terá um valor corresponde ao resultado da funcao.

O uso de Perlin Noise neste contexto resulta num "terreno/mar" com aspecto natural e dinamico. Sendo que os desvios "offset X e Y" são aleatorios, cria uma
sensação muito mais realista e dinamica.

O metodo update é chamada a cada frame, atualizando assim os dados do terreno, dando-lhes movimento, simulando as ondas do mar.
Os resultados das alturas no método Generate Heights são armazenados num array bidimensional.
O metodo Calculate Height recebe as coordenadas X e Y e usa o Perlin Noise com os desvios para calcular a altura.

No geral, o resultado é um terreno com geração  procedimental que altera de forma dinâmica, dando, neste caso, a sensação do movimento das ondas do mar.
