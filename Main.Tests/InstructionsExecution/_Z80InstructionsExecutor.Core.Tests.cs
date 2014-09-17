﻿using System;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Konamiman.Z80dotNet.Tests.InstructionsExecution
{
    public partial class Z80InstructionsExecutor
    {
        private Z80InstructionExecutor Sut { get; set; }
        private FakeProcessorAgent ProcessorAgent { get; set; }
        private IZ80Registers Registers { get; set; }
        private Fixture Fixture { get; set; }

        [SetUp]
        public void Setup()
        {
            Sut = new Z80InstructionExecutor();
            Sut.ProcessorAgent = ProcessorAgent = new FakeProcessorAgent();
            Registers = ProcessorAgent.Registers;
            Sut.InstructionFetchFinished += (s, e) => { };

            Fixture = new Fixture();
        }

		[Test]
		public void Instructions_execution_fire_FetchFinished_event_and_return_proper_T_states_count()
		{
		    var fetchFinishedEventsCount = 0;

		    Sut.InstructionFetchFinished += (sender, e) => fetchFinishedEventsCount++;

            SetNextFetches(0);
			Assert.AreEqual(4, Sut.Execute(0x00));
		    SetNextFetches(0, Fixture.Create<byte>(), Fixture.Create<byte>());
            Assert.AreEqual(10, Sut.Execute(0x01));

            SetNextFetches(0);
			Assert.AreEqual(8, Sut.Execute(0xCB));

			SetNextFetches(0x09, 0x09);
			Assert.AreEqual(15, Sut.Execute(0xDD));
			Assert.AreEqual(15, Sut.Execute(0xFD));

			SetNextFetches(0x40);
			Assert.AreEqual(12, Sut.Execute(0xED));

            SetNextFetches(0xCB, 0);
            Assert.AreEqual(23, Sut.Execute(0xDD));
            SetNextFetches(0xCB, 0);
            Assert.AreEqual(23, Sut.Execute(0xFD));
            
			Assert.AreEqual(8, fetchFinishedEventsCount);
        }

        [Test]
        public void Unsupported_instructions_just_return_8_TStates_elapsed()
        {
			var fetchFinishedEventsCount = 0;

			Sut.InstructionFetchFinished += (sender, e) => fetchFinishedEventsCount++;

			SetNextFetches(0x3F);
			Assert.AreEqual(8, Sut.Execute(0xED));
			SetNextFetches(0xC0);
			Assert.AreEqual(8, Sut.Execute(0xED));
            SetNextFetches(0x80);
			Assert.AreEqual(8, Sut.Execute(0xED));
            SetNextFetches(0x9F);
			Assert.AreEqual(8, Sut.Execute(0xED));

			Assert.AreEqual(4, fetchFinishedEventsCount);
        }

		[Test]
        public void Unsupported_instructions_invoke_overridable_method_ExecuteUnsopported_ED_Instruction()
		{
		    var sut = NewFakeInstructionExecutor();

			SetNextFetches(0x3F);
		    sut.Execute(0xED);
			SetNextFetches(0xC0);
		    sut.Execute(0xED);

			Assert.AreEqual(new Byte[] {0x3F, 0xC0}, sut.UnsupportedExecuted);
        }

        [Test]
		public void Execute_increases_R_appropriately()
        {
			Registers.R = 0xFE;

			Sut.Execute(0x00);
			Assert.AreEqual(0xFF, Registers.R);

            SetNextFetches(Fixture.Create<byte>(), Fixture.Create<byte>());
			Sut.Execute(0x01);
			Assert.AreEqual(0x80, Registers.R);

            SetNextFetches(0);
			Sut.Execute(0xCB);
			Assert.AreEqual(0x82, Registers.R);

			SetNextFetches(0x09, 0x09);
			Sut.Execute(0xDD);
			Sut.Execute(0xFD);
			Assert.AreEqual(0x86, Registers.R);

			SetNextFetches(0x40);
			Sut.Execute(0xED);
			Assert.AreEqual(0x88, Registers.R);

            SetNextFetches(0xCB, 0);
            Sut.Execute(0xDD);
            Assert.AreEqual(0x8A, Registers.R);
            SetNextFetches(0xCB, 0);
            Sut.Execute(0xFD);
            Assert.AreEqual(0x8C, Registers.R);
        }

        [Test]
        public void DD_FD_not_followed_by_valid_opcode_are_trated_as_nops()
        {
            var fetchFinishedEventsCount = 0;

		    Sut.InstructionFetchFinished += (sender, e) => fetchFinishedEventsCount++;

            SetNextFetches(0xFD);
            Assert.AreEqual(4, Sut.Execute(0xDD));
            SetNextFetches(0x01);
            Assert.AreEqual(4, Sut.Execute(0xFD));
            SetNextFetches(Fixture.Create<byte>(), Fixture.Create<byte>());
            Assert.AreEqual(10, Sut.Execute(0x01));

            Assert.AreEqual(3, fetchFinishedEventsCount);
        }
    }
}