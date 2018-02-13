import { expect } from 'chai';
import { shallow } from '@vue/test-utils';
import HelloWorld from '@/components/HelloWorld.vue';
describe('HelloWorld.vue', function () {
    it('renders props.msg when passed', function () {
        var msg = 'new message';
        var wrapper = shallow(HelloWorld, {
            propsData: { msg: msg },
        });
        expect(wrapper.text()).to.include(msg);
    });
});
//# sourceMappingURL=HelloWorld.spec.js.map