function checkYenNgua() {
  let res = [];
  let dong = 3;
  let cot = 4;
  let arr = [
    [2, 0, 5, -3],
    [8, 0, 7, 5],
    [5, 0, 11, 4],
  ];
  for (let i = 0; i < dong; i++) {
    let max = 0;
    for (let j = 0; j < cot; j++) {
      if (arr[i][j] > max) {
        max = arr[i][j];
      }
    }
    arr[i].map((item, index) => {
      if (item === max) {
        res.push([[item, { "row": i,"col":index }]]);
      }
    });
  }
  let final = [];
  for (let i = 0; i < dong; i++) {
    res[i].map(async(el) => {
    await checkCondition(el, final,dong,arr);
    });
  }

  return final

  function checkCondition(data, final,dong,arr,i) {
    let condition = true
    let value = data[0]
    let index = data[1].col
    let k = 0
    while (k < dong){
        if(value > arr[k][index] ){
            condition = false
            break
        }
        k++
    }
    if(condition) final.push([value,{"Row":data[1].row,"Col":index}])
  }
}

console.log(checkYenNgua());
