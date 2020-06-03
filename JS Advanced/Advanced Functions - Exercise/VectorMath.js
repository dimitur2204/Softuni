function result() {
    function add(vec1,vec2) {
        let newVector = [];
        newVector[0] = vec1[0] + vec2[0];
        newVector[1] = vec1[1] + vec2[1];
        return newVector;
    }
    function multiply(vec1,scalar) {
        let newVector = [];
        newVector[0] = vec1[0]*scalar;
        newVector[1] = vec1[1]*scalar;
        return newVector;
    }
    function length(vec1) {
        let length = Math.sqrt(vec1[0]**2 + vec1[1]**2);
        return length;
    }
    function dot(vec1,vec2) {
        let dot = vec1[0]*vec2[0] + vec1[1]*vec2[1];
        return dot;
    }
    function cross(vec1,vec2) {
        let cross = vec1[0]*vec2[1] + vec2[0]*vec1[1];
        return cross;
    }
    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
}
let solution = result();
console.log(solution.cross([3, 7], [1, 0]));