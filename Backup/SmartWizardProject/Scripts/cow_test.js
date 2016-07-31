

var expect = chai.expect;
var assert = chai.assert;
describe("Cow", function () {
    it("it should be current date: 13/12/2015", function () {
        expect('13/12/2015').to.equal(GetCurrentDate());
    });

    it("it should be 5", function () {
        expect(true).to.equal(GetInputEqualToFive(5));
    });

    it("it should not be 5", function () {
        assert.notEqual(GetInputEqualToFive(6), false); //if it is not right, it will throw an exception.
    })

    it('it should called 4 time', function () {
        expect('hello12345').to.equal(yell(5));
    });

    it("Ninja it should be 2", function () {
        var ninja = new Ninja();
        assert.equal(ninja.SwingSword(), 2);
    });

    it("Ninja2 swung should be true", function () {
        var ninja = new Ninja();
        var Ninja2 = new ninja.constructor();
        Ninja2.SwingSword();
        assert.equal(Ninja2.swung, true);
    }); 


});











