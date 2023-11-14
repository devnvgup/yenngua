function checkYenNgua() {
    let dong = 3
    let cot = 4
    let arr = [
        [2, 0, 5, -3], 
        [8, 0, 7, 5],
        [5, 0, 11, 4]
    ]
    let result = []
    let hashMap = {}
    for (let i = 0; i < dong; i++) {
        let clone = arr.map(innerArr => innerArr.slice());
        let maxArr = clone[i].sort((a, b) => a - b)
        let maxVal = maxArr[cot - 1]
        arr[i].map((item, index) => {
            if (item === maxVal) {
                hashMap[`${item}`] = index
                result.push(item)
            }
        })
    }

    return check(hashMap,result,dong,arr)
}
function check(map, res,dong,arr) {
    let result = []
    let k = 0
    while (k<res.length) {
        let conditionSmallest = true
        let value = res[k]
        let index = map[value]
        for (let i = 0; i < dong; i++) {
            if (arr[i][index] < value) {
                conditionSmallest = false
                break
            }
        }
        if(conditionSmallest) result.push(value,{"Position":[k,index]})
       k++
    }
    return result
}

console.log(checkYenNgua());